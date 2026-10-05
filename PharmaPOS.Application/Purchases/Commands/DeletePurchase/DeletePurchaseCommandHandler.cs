using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.Common.Errors;
using PharmaPOS.Domain.PurchaseAggregate;

namespace PharmaPOS.Application.Purchases.Commands.DeletePurchase;

public class DeletePurchaseCommandHandler(
	IPurchaseRepository purchaseRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeletePurchaseCommandHandler> logger) : IRequestHandler<DeletePurchaseCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeletePurchaseCommand command, CancellationToken ct)
	{
		var purchase = await purchaseRepo.GetByIdAsync(command.Id, ct);

		if (purchase == null)
			return CommonErrors<Purchase>.NotFound(command.Id);
		
		var hasSoldBatches = await batchRepo.HasSoldBatchesAsync(command.Id, ct);

		if (hasSoldBatches)
			return PurchaseApplicationErrors.CannotDeleteSoldPurchase;
		
		await batchRepo.DeleteBatchesByPurchaseIdAsync(command.Id, ct);
		
		purchaseRepo.Remove(purchase);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Purchase {PurchaseId} deleted", command.Id);
		return Result.Deleted;
	}
}
