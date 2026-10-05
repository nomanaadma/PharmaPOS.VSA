using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Customers.Queries.SearchCustomers;

[AuthorizeCommand(Permissions = Permissions.Customer.List)]
public record SearchCustomersQuery(string Term) : IRequest<List<CustomerSearchResult>>;
