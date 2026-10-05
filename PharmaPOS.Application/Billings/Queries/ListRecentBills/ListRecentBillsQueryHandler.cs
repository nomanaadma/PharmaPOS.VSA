using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Billings.Queries.ListRecentBills;

public class ListRecentBillsQueryHandler(
	IBillRepository billRepo) : IRequestHandler<ListRecentBillsQuery, List<CustomerBillsResponse>>
{
	public async Task<List<CustomerBillsResponse>> Handle(ListRecentBillsQuery query, CancellationToken ct)
	{
		var bills = await billRepo.GetRecentBillsAsync(query.CustomerId, query.Email, ct);
		var billsResponse = bills.Adapt<List<CustomerBillsResponse>>();
		return billsResponse;
	}
}
