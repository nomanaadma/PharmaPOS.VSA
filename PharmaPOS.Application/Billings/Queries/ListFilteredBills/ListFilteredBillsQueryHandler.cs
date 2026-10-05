using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Billings.Queries.ListFilteredBills;

public class ListFilteredBillsQueryHandler(
	IBillRepository billRepo) : IRequestHandler<ListFilteredBillsQuery, DataTableResponse<BillingListResponse>>
{
	public async Task<DataTableResponse<BillingListResponse>> Handle(ListFilteredBillsQuery query, CancellationToken ct)
	{
		return await billRepo.GetFilteredBillsAsync(query.Request, query.Columns, ct);
	}
}
