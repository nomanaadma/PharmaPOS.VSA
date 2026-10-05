using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Application.Common.Services;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Billings.Commands.UpdateBill;

public class UpdateBillCommandHandler(
	IBillRepository billRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	CustomerService customerService,
	ILogger<UpdateBillCommandHandler> logger) : IRequestHandler<UpdateBillCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdateBillCommand command, CancellationToken ct)
	{
		var request = command.Request;
		
		var bill = await billRepo.GetBillWithItemsAsync(command.Id, ct);

		if (bill == null)
			return CommonErrors<Bill>.NotFound(command.Id);

		var customerId = request.CustomerId ?? bill.CustomerId;
		if (customerId == 0)
		{
			var customerRequest = CustomerHelper.CreateCustomerRequest(request);
			
			var customerResult = await customerService.GetOrCreateCustomerAsync(customerRequest, ct);
			
			if (customerResult.IsError)
				return customerResult.Errors;
			customerId = customerResult.Value;
		}

		var billFields = new BillFields(
			customerId,
			request.Name,
			request.Email,
			request.Mobile,
			request.Method,
			request.Date,
			request.SubTotal,
			request.Tax,
			request.Discount,
			request.Amount,
			request.Note
		);

		var updateResult = bill.Update(billFields);
		if (updateResult.IsError)
			return updateResult.Errors;

		// Pre-fetch all batches for both old and new items in a single query
		var oldBatchIds = bill.Items.Select(i => i.BatchId).ToList();
		var newBatchIds = request.Items.Select(i => i.Batch).ToList();
		var allBatchIds = oldBatchIds.Union(newBatchIds).Distinct().ToList();

		var batches = await batchRepo.GetBatchByIdsAsync(allBatchIds, ct);

		// Revert sold quantities for old items
		foreach (var oldItem in bill.Items)
		{
			if (!batches.TryGetValue(oldItem.BatchId, out var batch))
				return BillApplicationErrors.BatchNotFound(oldItem.BatchId, oldItem.MedicineId);

			var soldResult = batch.UpdateSold(-oldItem.Pricing.Qty);
			if (soldResult.IsError)
				return soldResult.Errors;
		}

		// Clear old items using aggregate root method
		bill.ClearItems();

		// Add new items and update sold quantities
		foreach (var item in request.Items)
		{
			var pricingResult = PricingHelper.CreatePricingDetails(item);
			if (pricingResult.IsError) return pricingResult.Errors;

			var billItemFields = new BillItemFields(item.MedicineId, item.Batch, pricingResult.Value);
			
			// Use aggregate root method
			var addResult = bill.AddItem(billItemFields);
			
			if (addResult.IsError)
				return addResult.Errors;
			
			if (!batches.TryGetValue(item.Batch, out var batch))
				return BillApplicationErrors.BatchNotFound(item.Batch, item.MedicineId);

			// Validate stock availability
			var available = batch.Pricing.Qty - batch.Sold;
			if (item.Qty > available)
				return BillApplicationErrors.InsufficientStock(batch.BatchName, available, item.Qty);
			
			var soldResult = batch.UpdateSold(item.Qty);
			if (soldResult.IsError)
				return soldResult.Errors;
		}

		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Bill {BillId} updated with {ItemCount} items", bill.Id, request.Items.Count);
		return Result.Updated;
	}
}

