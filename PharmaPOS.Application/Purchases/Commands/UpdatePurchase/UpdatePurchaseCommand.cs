using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Purchases.Commands.UpdatePurchase;

[AuthorizeCommand(Permissions = Permissions.Purchase.Edit)]
public record UpdatePurchaseCommand(int Id, PurchaseRequest Request) : IRequest<ErrorOr<Updated>>;
