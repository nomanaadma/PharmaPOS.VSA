using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Application.Suppliers.Commands.DeleteSupplier;

public class DeleteSupplierCommandHandler(
	ISupplierRepository supplierRepo,
	IPurchaseRepository purchaseRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeleteSupplierCommandHandler> logger) : IRequestHandler<DeleteSupplierCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeleteSupplierCommand command, CancellationToken ct)
	{
		var supplier = await supplierRepo.GetByIdAsync(command.Id, ct);
		if (supplier == null)
			return CommonErrors<Supplier>.NotFound(command.Id);

		var hasPurchases = await purchaseRepo.HasPurchasesBySupplierAsync(command.Id, ct);
		if (hasPurchases)
			return SupplierApplicationErrors.CannotDeleteWithPurchases;

		supplierRepo.Remove(supplier);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Supplier {SupplierId} deleted", command.Id);
		return Result.Deleted;
	}
}

