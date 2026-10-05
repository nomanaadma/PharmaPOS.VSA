using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.CustomerAggregate;

namespace PharmaPOS.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler(
	ICustomerRepository customerRepo,
	IUnitOfWork unitOfWork,
	ILogger<UpdateCustomerCommandHandler> logger) : IRequestHandler<UpdateCustomerCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdateCustomerCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var customer = await customerRepo.GetByIdAsync(command.Id, ct);
		if (customer == null)
			return CommonErrors<Customer>.NotFound(command.Id);

		if (request.Email != null && await customerRepo.ExistsByEmailAsync(request.Email, command.Id, ct))
			return CustomerApplicationErrors.EmailNotUnique;
		
		var customerFields = request.Adapt<CustomerFields>();
		
		var updateResult = customer.Update(customerFields);
		if (updateResult.IsError)
			return updateResult.Errors;

		customerRepo.Update(customer);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Customer {CustomerId} updated", command.Id);
		return Result.Updated;
	}
}

