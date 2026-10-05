using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Customers.Commands.UpdateCustomer;

[AuthorizeCommand(Permissions = Permissions.Customer.Edit)]
public record UpdateCustomerCommand(int Id, CustomerRequest Request) : IRequest<ErrorOr<Updated>>;
