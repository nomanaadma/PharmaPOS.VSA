using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;

namespace PharmaPOS.Application.Stock.Commands.UpdateStock;

public class UpdateStockCommandHandler(
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<UpdateStockCommandHandler> logger) : IRequestHandler<UpdateStockCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdateStockCommand command, CancellationToken ct)
	{
		var batch = await batchRepo.GetBatchAsync(command.MedicineId, command.Id, ct);
		
		if (batch == null)
			return StockApplicationErrors.NotFound;
		
		var targetTotalSold = batch.Pricing.Qty - command.Available;
		var quantityJustSold = targetTotalSold - batch.Sold;

		var soldResult = batch.UpdateSold(quantityJustSold);
		if (soldResult.IsError)
			return soldResult.Errors;
		
		await unitOfWork.SaveChangesAsync(ct);
		
		logger.LogInformation("Stock {BatchId} for Medicine {MedicineId} updated to available: {Available}", command.Id, command.MedicineId, command.Available);
		return Result.Updated;
	}
}
