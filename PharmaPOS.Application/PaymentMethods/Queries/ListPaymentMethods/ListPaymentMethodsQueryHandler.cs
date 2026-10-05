using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethods;

public class ListPaymentMethodsQueryHandler(
	IPaymentMethodRepository paymentMethodRepo) : IRequestHandler<ListPaymentMethodsQuery, List<PaymentMethodResponse>>
{
	public async Task<List<PaymentMethodResponse>> Handle(ListPaymentMethodsQuery query, CancellationToken ct)
	{
		var methods = await paymentMethodRepo.GetAllAsync(ct);
		var methodsResponse = methods.Adapt<List<PaymentMethodResponse>>();
		return methodsResponse;
	}
}
