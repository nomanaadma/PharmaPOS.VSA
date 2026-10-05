using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Application.Common.Services;
using PharmaPOS.Domain.CustomerAggregate;

namespace PharmaPOS.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(
	ICustomerRepository customerRepo,
	CustomerService customerService) : IRequestHandler<CreateCustomerCommand, ErrorOr<Created>>
{
	public async Task<ErrorOr<Created>> Handle(CreateCustomerCommand command, CancellationToken ct)
	{
		var request = command.Request;

		if (request.Email != null && await customerRepo.ExistsByEmailAsync(request.Email, null, ct))
			return CustomerApplicationErrors.EmailNotUnique;

		
		var customerResult = await customerService.SaveCustomerAsync(request, "Customer {CustomerId} created", ct);
		if(customerResult.IsError)
			return customerResult.Errors;
		
		return Result.Created;

	}
}
