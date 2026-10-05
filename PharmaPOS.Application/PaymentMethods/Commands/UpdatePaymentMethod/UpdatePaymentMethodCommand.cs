using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.PaymentMethods.Commands.UpdatePaymentMethod;

[AuthorizeCommand(Permissions = Permissions.PaymentMethod.Edit)]
public record UpdatePaymentMethodCommand(int Id, PaymentMethodRequest Request) : IRequest<ErrorOr<Updated>>;
