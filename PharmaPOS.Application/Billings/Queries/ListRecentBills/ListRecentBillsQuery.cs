using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Queries.ListRecentBills;

[AuthorizeCommand(Permissions = Permissions.Billing.List)]
public record ListRecentBillsQuery(int CustomerId, string? Email) : IRequest<List<CustomerBillsResponse>>;
