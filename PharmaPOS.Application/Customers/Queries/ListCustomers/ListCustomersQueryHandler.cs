using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Customers.Queries.ListCustomers;

public class ListCustomersQueryHandler(
	ICustomerRepository customerRepo) : IRequestHandler<ListCustomersQuery, List<CustomerResponse>>
{
	public async Task<List<CustomerResponse>> Handle(ListCustomersQuery query, CancellationToken ct)
	{
		var customers = await customerRepo.GetAllAsync(ct);
		var customerResponse = customers.Adapt<List<CustomerResponse>>();
		return customerResponse;
	}
}
