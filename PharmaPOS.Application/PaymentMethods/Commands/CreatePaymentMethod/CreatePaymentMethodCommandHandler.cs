using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.PaymentMethodAggregate;

namespace PharmaPOS.Application.PaymentMethods.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommandHandler(
	IPaymentMethodRepository paymentMethodRepo,
	IUnitOfWork unitOfWork,
	ILogger<CreatePaymentMethodCommandHandler> logger) : IRequestHandler<CreatePaymentMethodCommand, ErrorOr<Created>>
{
	public async Task<ErrorOr<Created>> Handle(CreatePaymentMethodCommand command, CancellationToken ct)
	{
		var request = command.Request;

		if (await paymentMethodRepo.ExistsByNameAsync(request.Name, null, ct))
			return PaymentMethodApplicationErrors.NameNotUnique;

		var paymentMethodFields = request.Adapt<PaymentMethodFields>();

		var methodResult = PaymentMethod.Create(paymentMethodFields);
		if (methodResult.IsError)
			return methodResult.Errors;

		var method = methodResult.Value;
		await paymentMethodRepo.AddAsync(method, ct);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Payment method {MethodId} '{Name}' created", method.Id, method.Name);
		return Result.Created;
	}
}
