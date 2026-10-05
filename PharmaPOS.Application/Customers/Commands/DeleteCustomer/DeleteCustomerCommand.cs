using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Customers.Commands.DeleteCustomer;

[AuthorizeCommand(Permissions = Permissions.Customer.Delete)]
public record DeleteCustomerCommand(int Id) : IRequest<ErrorOr<Deleted>>;
