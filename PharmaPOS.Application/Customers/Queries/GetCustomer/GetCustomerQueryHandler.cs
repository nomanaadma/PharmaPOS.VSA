using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.CustomerAggregate;

namespace PharmaPOS.Application.Customers.Queries.GetCustomer;

public class GetCustomerQueryHandler(
	ICustomerRepository customerRepo) : IRequestHandler<GetCustomerQuery, ErrorOr<CustomerResponse>>
{
	public async Task<ErrorOr<CustomerResponse>> Handle(GetCustomerQuery query, CancellationToken ct)
	{
		var customer = await customerRepo.GetByIdAsync(query.Id, ct);
		if (customer == null)
			return CommonErrors<Customer>.NotFound(query.Id);
				
		var customerResponse =  customer.Adapt<CustomerResponse>();				

		return customerResponse;
	}
}

