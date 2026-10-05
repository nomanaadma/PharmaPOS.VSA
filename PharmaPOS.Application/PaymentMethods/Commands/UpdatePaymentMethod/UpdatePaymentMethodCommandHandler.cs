using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.PaymentMethodAggregate;

namespace PharmaPOS.Application.PaymentMethods.Commands.UpdatePaymentMethod;

public class UpdatePaymentMethodCommandHandler(
	IPaymentMethodRepository paymentMethodRepo,
	IUnitOfWork unitOfWork,
	ILogger<UpdatePaymentMethodCommandHandler> logger) : IRequestHandler<UpdatePaymentMethodCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdatePaymentMethodCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var method = await paymentMethodRepo.GetByIdAsync(command.Id, ct);
		if (method == null)
			return CommonErrors<PaymentMethod>.NotFound(command.Id);

		if (await paymentMethodRepo.ExistsByNameAsync(request.Name, command.Id, ct))
			return PaymentMethodApplicationErrors.NameNotUnique;

		var paymentMethodFields = request.Adapt<PaymentMethodFields>();

		var updateResult = method.Update(paymentMethodFields);
		if (updateResult.IsError)
			return updateResult.Errors;

		paymentMethodRepo.Update(method);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Payment method {MethodId} updated", command.Id);
		return Result.Updated;
	}
}

