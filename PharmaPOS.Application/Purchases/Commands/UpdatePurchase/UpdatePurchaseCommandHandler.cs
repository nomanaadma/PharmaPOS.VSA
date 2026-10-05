using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.PurchaseAggregate;

namespace PharmaPOS.Application.Purchases.Commands.UpdatePurchase;

public class UpdatePurchaseCommandHandler(
	IPurchaseRepository purchaseRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<UpdatePurchaseCommandHandler> logger) : IRequestHandler<UpdatePurchaseCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdatePurchaseCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var existingPurchase = await purchaseRepo.GetByIdAsync(command.Id, ct);

		if (existingPurchase == null)
			return CommonErrors<Purchase>.NotFound(command.Id);

		var purchaseFields = new PurchaseFields(
			request.Supplier,
			request.Date,
			request.SubTotal,
			request.Tax,
			request.Discount,
			request.Amount,
			request.Note
		);

		var updateResult = existingPurchase.Update(purchaseFields);
		if (updateResult.IsError)
			return updateResult.Errors;

		var submittedBatchIds = request.Items.Where(i => i.Id != 0).Select(i => i.Id).ToHashSet();

		var existingBatches = await batchRepo.GetBatchesByPurchaseIdAsync(command.Id, ct);
		
		var batchesToRemove = existingBatches.Where(b => !submittedBatchIds.Contains(b.Id)).ToList();
		
		foreach (var batch in batchesToRemove)
		{
			// Business rule: can't delete a batch that has been sold
			if (batch.Sold > 0)
				return PurchaseApplicationErrors.CannotDelete(batch.BatchName);
		}
		
		batchRepo.RemoveRange(batchesToRemove);
		
		var batches = new List<Batch>();

		foreach (var item in request.Items)
		{
			var pricingResult = PricingHelper.CreatePricingDetails(item);
			if (pricingResult.IsError) return pricingResult.Errors;

			var batchFields = new BatchFields(
				item.Batch,
				item.Expiry,
				item.Pqty,
				pricingResult.Value,
				item.Purchaseprice,
				item.MedicineId,
				command.Id
			);

			if (item.Id != 0)
			{
				var existingBatch = existingBatches.FirstOrDefault(b => b.Id == item.Id);

				if (existingBatch == null) continue;

				if (pricingResult.Value.Qty < existingBatch.Sold)
					return PurchaseApplicationErrors.CannotUpdate(existingBatch.BatchName, pricingResult.Value.Qty,
						existingBatch.Sold);

				var batchUpdateResult = existingBatch.Update(batchFields);
				if (batchUpdateResult.IsError)
					return batchUpdateResult.Errors;
			}
			else
			{
				var batchResult = Batch.Create(batchFields);
				if (batchResult.IsError)
					return batchResult.Errors;
				
				batches.Add(batchResult.Value);
			}
		}

		if (batches.Count != 0)
		{
			await batchRepo.AddRangeAsync(batches, ct);
		}

		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Purchase {PurchaseId} updated with {BatchCount} batches", existingPurchase.Id, request.Items.Count);
		return Result.Updated;
	}
}

