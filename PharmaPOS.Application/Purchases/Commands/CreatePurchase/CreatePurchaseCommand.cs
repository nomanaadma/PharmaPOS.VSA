using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Purchases.Commands.CreatePurchase;

[AuthorizeCommand(Permissions = Permissions.Purchase.Add)]
public record CreatePurchaseCommand(PurchaseRequest Request) : IRequest<ErrorOr<Created>>;
