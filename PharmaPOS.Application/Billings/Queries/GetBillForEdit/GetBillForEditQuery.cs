using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Queries.GetBillForEdit;

[AuthorizeCommand(Permissions = Permissions.Billing.Edit)]
public record GetBillForEditQuery(int Id) : IRequest<ErrorOr<BillEditResponse>>;
