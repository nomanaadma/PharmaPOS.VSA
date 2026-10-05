using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Queries.GetBill;

[AuthorizeCommand(Permissions = Permissions.Billing.View)]
public record GetBillQuery(int Id) : IRequest<ErrorOr<BillResponse>>;
