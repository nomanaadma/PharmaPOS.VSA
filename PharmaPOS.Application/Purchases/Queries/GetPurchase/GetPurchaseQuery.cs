using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Purchases.Queries.GetPurchase;

[AuthorizeCommand(Permissions = Permissions.Purchase.View)]
public record GetPurchaseQuery(int Id) : IRequest<ErrorOr<PurchaseResponse>>;
