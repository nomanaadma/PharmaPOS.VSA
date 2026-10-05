using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethods;

[AuthorizeCommand(Permissions = Permissions.PaymentMethod.List)]
public record ListPaymentMethodsQuery : IRequest<List<PaymentMethodResponse>>;
