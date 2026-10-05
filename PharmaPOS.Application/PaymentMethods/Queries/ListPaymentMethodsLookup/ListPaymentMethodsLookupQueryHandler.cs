using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethodsLookup;

public class ListPaymentMethodsLookupQueryHandler(
	IPaymentMethodRepository paymentMethodRepo) : IRequestHandler<ListPaymentMethodsLookupQuery, IEnumerable<LookupItem>>
{
	public async Task<IEnumerable<LookupItem>> Handle(ListPaymentMethodsLookupQuery query, CancellationToken ct)
	{
		return await paymentMethodRepo.GetActiveLookupListAsync(ct);
	}
}
