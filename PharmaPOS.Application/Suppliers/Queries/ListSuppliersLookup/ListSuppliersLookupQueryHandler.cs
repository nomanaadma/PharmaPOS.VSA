using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Suppliers.Queries.ListSuppliersLookup;

public class ListSuppliersLookupQueryHandler(
	ISupplierRepository supplierRepo) : IRequestHandler<ListSuppliersLookupQuery, IEnumerable<LookupItem>>
{
	public async Task<IEnumerable<LookupItem>> Handle(ListSuppliersLookupQuery query, CancellationToken ct)
	{
		return await supplierRepo.GetLookupListAsync(ct);
	}
}
