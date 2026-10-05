using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PaymentMethodAggregate;

namespace PharmaPOS.Application.PaymentMethods.Queries.GetPaymentMethod;

public class GetPaymentMethodQueryHandler(
	IPaymentMethodRepository paymentMethodRepo) : IRequestHandler<GetPaymentMethodQuery, ErrorOr<PaymentMethodResponse>>
{
	public async Task<ErrorOr<PaymentMethodResponse>> Handle(GetPaymentMethodQuery query, CancellationToken ct)
	{
		var method = await paymentMethodRepo.GetByIdAsync(query.Id, ct);
		if (method == null)
			return CommonErrors<PaymentMethod>.NotFound(query.Id);

		var methodResponse = method.Adapt<PaymentMethodResponse>();
		return methodResponse;
	}
}

