using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.PurchaseAggregate;

namespace PharmaPOS.Application.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommandHandler(
	IPurchaseRepository purchaseRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<CreatePurchaseCommandHandler> logger) : IRequestHandler<CreatePurchaseCommand, ErrorOr<Created>>
{
	public async Task<ErrorOr<Created>> Handle(CreatePurchaseCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var purchaseFields = new PurchaseFields(
			request.Supplier,
			request.Date,
			request.SubTotal,
			request.Tax,
			request.Discount,
			request.Amount,
			request.Note
		);

		var purchaseResult = Purchase.Create(purchaseFields);
		if (purchaseResult.IsError)
			return purchaseResult.Errors;

		var purchase = purchaseResult.Value;
		
		await using var transaction = await unitOfWork.BeginTransactionAsync(ct);
		
		try
		{
			await purchaseRepo.AddAsync(purchase, ct);
			await unitOfWork.SaveChangesAsync(ct);

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
					purchase.Id
				);

				var batchResult = Batch.Create(batchFields);
			
				if (batchResult.IsError)
					return batchResult.Errors;
			
				batches.Add(batchResult.Value);
			}

			await batchRepo.AddRangeAsync(batches, ct);
			await unitOfWork.SaveChangesAsync(ct);
			
			await transaction.CommitAsync(ct);
			
			logger.LogInformation("Purchase {PurchaseId} created with {BatchCount} batches", purchase.Id, request.Items.Count);
			return Result.Created;
		}
		catch
		{
			await transaction.RollbackAsync(ct);
			throw;
		}
	}
}
