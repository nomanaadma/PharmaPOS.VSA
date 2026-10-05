using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Customers.Queries.GetCustomer;

[AuthorizeCommand(Permissions = Permissions.Customer.View)]
public record GetCustomerQuery(int Id) : IRequest<ErrorOr<CustomerResponse>>;
