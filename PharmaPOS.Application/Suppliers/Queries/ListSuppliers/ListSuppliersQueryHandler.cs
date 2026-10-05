using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Suppliers.Queries.ListSuppliers;

public class ListSuppliersQueryHandler(
	ISupplierRepository supplierRepo) : IRequestHandler<ListSuppliersQuery, List<SupplierResponse>>
{
	public async Task<List<SupplierResponse>> Handle(ListSuppliersQuery query, CancellationToken ct)
	{
		var suppliers = await supplierRepo.GetAllAsync(ct);
		var suppliersResponse = suppliers.Adapt<List<SupplierResponse>>();
		return suppliersResponse;
	}
}
