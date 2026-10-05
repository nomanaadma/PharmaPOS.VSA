using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Billings.Queries.GetBillForEdit;

public class GetBillForEditQueryHandler(
	IBillRepository billRepo,
	IMedicineRepository medicineRepo,
	IBatchRepository batchRepo) : IRequestHandler<GetBillForEditQuery, ErrorOr<BillEditResponse>>
{
	public async Task<ErrorOr<BillEditResponse>> Handle(GetBillForEditQuery query, CancellationToken ct)
	{
		var bill = await billRepo.GetBillWithItemsAsync(query.Id, ct);

		if (bill == null)
			return CommonErrors<Bill>.NotFound(query.Id);

		var medicineIds = bill.Items.Select(i => i.MedicineId).Distinct().ToList();
		var medicineNames = await medicineRepo.GetMedicineNamesByIdsAsync(medicineIds, ct);
		
		var itemBatchIds = bill.Items.Select(i => i.BatchId).Distinct().ToList();

		var activeBatches = await batchRepo.GetNonExpiredBatchesAsync(medicineIds, ct);

		// Also include the item's own batch even if expired/inactive
		var missingBatchIds = itemBatchIds.Except(activeBatches.Select(b => b.Id)).ToList();
		if (missingBatchIds.Count > 0)
		{
			var extraBatches = (await batchRepo.GetBatchByIdsAsync(missingBatchIds, ct)).Values.ToList();
			activeBatches.AddRange(extraBatches);
		}

		var batchesByMedicine = activeBatches
			.GroupBy(b => b.MedicineId)
			.ToDictionary(g => g.Key, g => g.ToList());
		
		var billEditResponse = bill.Adapt<BillEditResponse>();
		
		foreach (var item in billEditResponse.Items)
		{
			item.MedicineName = medicineNames.GetValueOrDefault(item.MedicineId, "");
			
			batchesByMedicine.TryGetValue(item.MedicineId, out var batches);
			var batch = batches?.FirstOrDefault(b => b.Id == item.BatchId);

			item.BatchName = batch?.BatchName ?? "";
			item.Expiry = batch?.Expiry ?? "";
			item.Batches = batches?.Adapt<IReadOnlyCollection<BillEditBatchDto>>() ?? [];
		}
		
		return billEditResponse;
	}
}

