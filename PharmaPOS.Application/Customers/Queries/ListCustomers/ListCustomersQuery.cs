using MediatR;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Customers.Queries.ListCustomers;

[AuthorizeCommand(Permissions = Permissions.Customer.List)]
public record ListCustomersQuery : IRequest<List<CustomerResponse>>;
