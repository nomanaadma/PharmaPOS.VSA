using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.PaymentMethods.Commands.CreatePaymentMethod;

[AuthorizeCommand(Permissions = Permissions.PaymentMethod.Add)]
public record CreatePaymentMethodCommand(PaymentMethodRequest Request) : IRequest<ErrorOr<Created>>;
