using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Customers.Commands.CreateCustomer;

[AuthorizeCommand(Permissions = Permissions.Customer.Add)]
public record CreateCustomerCommand(CustomerRequest Request) : IRequest<ErrorOr<Created>>;
