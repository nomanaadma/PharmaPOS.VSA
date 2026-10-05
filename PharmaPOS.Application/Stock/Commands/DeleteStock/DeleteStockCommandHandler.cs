using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Application.Stock.Commands.DeleteStock;

public class DeleteStockCommandHandler(
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeleteStockCommandHandler> logger) : IRequestHandler<DeleteStockCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeleteStockCommand command, CancellationToken ct)
	{
		var batch = await batchRepo.GetByIdAsync(command.Id, ct);

		if (batch == null)
			return StockApplicationErrors.NotFound;
		
		batch.UpdateStatus(Status.InActive);
		await unitOfWork.SaveChangesAsync(ct);
		
		logger.LogInformation("Stock {BatchId} marked as InActive", command.Id);
		return Result.Deleted;
	}
}
