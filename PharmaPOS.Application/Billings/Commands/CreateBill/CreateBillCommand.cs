using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Commands.CreateBill;

[AuthorizeCommand(Permissions = Permissions.Billing.Add)]
public record CreateBillCommand(BillingRequest Request) : IRequest<ErrorOr<int>>;
