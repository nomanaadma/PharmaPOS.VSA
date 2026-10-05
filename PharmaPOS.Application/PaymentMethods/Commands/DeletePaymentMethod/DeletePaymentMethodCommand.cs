using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.PaymentMethods.Commands.DeletePaymentMethod;

[AuthorizeCommand(Permissions = Permissions.PaymentMethod.Delete)]
public record DeletePaymentMethodCommand(int Id) : IRequest<ErrorOr<Deleted>>;
