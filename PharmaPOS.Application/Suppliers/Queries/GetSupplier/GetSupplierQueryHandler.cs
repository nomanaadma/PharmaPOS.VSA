using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Application.Suppliers.Queries.GetSupplier;

public class GetSupplierQueryHandler(
	ISupplierRepository supplierRepo) : IRequestHandler<GetSupplierQuery, ErrorOr<SupplierResponse>>
{
	public async Task<ErrorOr<SupplierResponse>> Handle(GetSupplierQuery query, CancellationToken ct)
	{
		var supplier = await supplierRepo.GetByIdAsync(query.Id, ct);
		if (supplier == null)
			return CommonErrors<Supplier>.NotFound(query.Id);

		var supplierResponse = supplier.Adapt<SupplierResponse>();
		return supplierResponse;
	}
}

