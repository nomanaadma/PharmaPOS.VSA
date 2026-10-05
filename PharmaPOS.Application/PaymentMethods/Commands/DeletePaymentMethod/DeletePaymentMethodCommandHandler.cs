using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.PaymentMethodAggregate;

namespace PharmaPOS.Application.PaymentMethods.Commands.DeletePaymentMethod;

public class DeletePaymentMethodCommandHandler(
	IPaymentMethodRepository paymentMethodRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeletePaymentMethodCommandHandler> logger) : IRequestHandler<DeletePaymentMethodCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeletePaymentMethodCommand command, CancellationToken ct)
	{
		var method = await paymentMethodRepo.GetByIdAsync(command.Id, ct);
		if (method == null)
			return CommonErrors<PaymentMethod>.NotFound(command.Id);

		paymentMethodRepo.Remove(method);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Payment method {MethodId} deleted", command.Id);
		return Result.Deleted;
	}
}

