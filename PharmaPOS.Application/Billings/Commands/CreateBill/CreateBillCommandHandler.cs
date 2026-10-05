using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Application.Common.Services;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Billings.Commands.CreateBill;

public class CreateBillCommandHandler(
	IBillRepository billRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	CustomerService customerService,
	ILogger<CreateBillCommandHandler> logger) : IRequestHandler<CreateBillCommand, ErrorOr<int>>
{
	public async Task<ErrorOr<int>> Handle(CreateBillCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var customerRequest = CustomerHelper.CreateCustomerRequest(request);
		
		var customerResult = await customerService.GetOrCreateCustomerAsync(customerRequest, ct); 
		
		if (customerResult.IsError)
			return customerResult.Errors;

		var billFields = new BillFields(
			customerResult.Value,
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

		var billResult = Bill.Create(billFields);
		if (billResult.IsError)
			return billResult.Errors;

		var bill = billResult.Value;

		// Pre-fetch all needed batches in a single query (fixes N+1)
		var batchIds = request.Items.Select(i => i.Batch).Distinct().ToList();
		var batches = await batchRepo.GetBatchByIdsAsync(batchIds, ct);

		foreach (var item in request.Items)
		{
			var pricingResult = PricingHelper.CreatePricingDetails(item);
			if (pricingResult.IsError) return pricingResult.Errors;

			var billItemFields = new BillItemFields(item.MedicineId, item.Batch, pricingResult.Value);

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

		await billRepo.AddAsync(bill, ct);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Bill {BillId} created with {ItemCount} items", bill.Id, request.Items.Count);
		return bill.Id;
	}
}
