using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Purchases.Commands.DeletePurchase;

[AuthorizeCommand(Permissions = Permissions.Purchase.Delete)]
public record DeletePurchaseCommand(int Id) : IRequest<ErrorOr<Deleted>>;
