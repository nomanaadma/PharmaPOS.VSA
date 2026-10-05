using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.PaymentMethods.Queries.GetPaymentMethod;

[AuthorizeCommand(Permissions = Permissions.PaymentMethod.Edit)]
public record GetPaymentMethodQuery(int Id) : IRequest<ErrorOr<PaymentMethodResponse>>;
