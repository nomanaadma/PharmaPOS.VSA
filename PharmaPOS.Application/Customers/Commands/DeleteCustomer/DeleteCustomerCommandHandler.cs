using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.CustomerAggregate;

namespace PharmaPOS.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(
	ICustomerRepository customerRepo,
	IBillRepository billRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeleteCustomerCommandHandler> logger) : IRequestHandler<DeleteCustomerCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeleteCustomerCommand command, CancellationToken ct)
	{
		var customer = await customerRepo.GetByIdAsync(command.Id, ct);
		if (customer == null)
			return CommonErrors<Customer>.NotFound(command.Id);

		var hasBills = await billRepo.HasBillsByCustomerAsync(command.Id, ct);
		if (hasBills)
			return CustomerApplicationErrors.CannotDeleteWithBills;

		customerRepo.Remove(customer);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Customer {CustomerId} deleted", command.Id);
		return Result.Deleted;
	}
}

