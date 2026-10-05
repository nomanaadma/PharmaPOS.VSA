using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Commands.UpdateBill;

[AuthorizeCommand(Permissions = Permissions.Billing.Edit)]
public record UpdateBillCommand(int Id, BillingRequest Request) : IRequest<ErrorOr<Updated>>;
