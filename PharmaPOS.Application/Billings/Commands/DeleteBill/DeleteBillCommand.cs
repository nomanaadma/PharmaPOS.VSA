using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Billings.Commands.DeleteBill;

[AuthorizeCommand(Permissions = Permissions.Billing.Delete)]
public record DeleteBillCommand(int Id) : IRequest<ErrorOr<Deleted>>;
