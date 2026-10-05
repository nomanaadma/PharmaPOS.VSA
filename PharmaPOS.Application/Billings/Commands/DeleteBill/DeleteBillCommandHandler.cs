using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Billings.Commands.DeleteBill;

public class DeleteBillCommandHandler(
	IBillRepository billRepo,
	IBatchRepository batchRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeleteBillCommandHandler> logger) : IRequestHandler<DeleteBillCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeleteBillCommand command, CancellationToken ct)
	{
		var bill = await billRepo.GetBillWithItemsAsync(command.Id, ct);

		if (bill == null)
			return CommonErrors<Bill>.NotFound(command.Id);

		// Pre-fetch all batches in a single query
		var batchIds = bill.Items.Select(i => i.BatchId).Distinct().ToList();
		var batches = await batchRepo.GetBatchByIdsAsync(batchIds, ct);
		 
		// Revert sold quantities
		foreach (var item in bill.Items)
		{
			if (!batches.TryGetValue(item.BatchId, out var batch))
				return BillApplicationErrors.BatchNotFound(item.BatchId, item.MedicineId);

			var soldResult = batch.UpdateSold(-item.Pricing.Qty);
			if (soldResult.IsError)
				return soldResult.Errors;
		}

		bill.Delete();
		billRepo.Remove(bill);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Bill {BillId} deleted, {ItemCount} items reverted", command.Id, bill.Items.Count);
		return Result.Deleted;
	}
}

