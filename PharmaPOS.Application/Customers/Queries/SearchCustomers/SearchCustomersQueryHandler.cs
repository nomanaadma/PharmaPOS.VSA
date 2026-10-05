using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Customers.Queries.SearchCustomers;

public class SearchCustomersQueryHandler(
	ICustomerRepository customerRepo) : IRequestHandler<SearchCustomersQuery, List<CustomerSearchResult>>
{
	public async Task<List<CustomerSearchResult>> Handle(SearchCustomersQuery query, CancellationToken ct)
	{
		return await customerRepo.SearchCustomersAsync(query.Term, 7, ct);
	}
}
