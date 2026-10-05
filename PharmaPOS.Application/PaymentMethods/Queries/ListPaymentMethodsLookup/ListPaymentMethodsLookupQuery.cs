using MediatR;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethodsLookup;

public record ListPaymentMethodsLookupQuery : IRequest<IEnumerable<LookupItem>>;
