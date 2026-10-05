using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Extensions;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Medicines.Queries.GetMedicineStockSummary;

public class GetMedicineStockSummaryQueryHandler(
	IBatchRepository batchRepo,
	IMedicineRepository medicineRepo) : IRequestHandler<GetMedicineStockSummaryQuery, (IEnumerable<BatchResponse> liveBatches, IEnumerable<BatchResponse> badBatches)>
{
	public async Task<(IEnumerable<BatchResponse> liveBatches, IEnumerable<BatchResponse> badBatches)> Handle(GetMedicineStockSummaryQuery query, CancellationToken ct)
	{
		var today = DateTime.UtcNow.Date;
		var currentMonthStr = new DateTime(today.Year, today.Month, 1).ExpiryFormat();

		var batchesQuery = await batchRepo.GetActiveBatchesAsync(query.MedicineId, ct);
		
		var batchesResponse = batchesQuery.Adapt<List<BatchResponse>>();
		
		// Fetch medicine names for display
		var medicineIds = batchesResponse.Select(b => b.MedicineId).Distinct().ToList();
		var medicineNames = await medicineRepo.GetMedicineNamesByIdsAsync(medicineIds, ct);
		
		batchesResponse = batchesResponse
			.Select(br => br with { Name = medicineNames.GetValueOrDefault(br.MedicineId, "") })
			.ToList();
		
		var liveBatches = batchesResponse.Where(b => 
				string.CompareOrdinal(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) >= 0);
		
		var badBatches = batchesResponse.Where(b => 
				string.CompareOrdinal(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) < 0)
			.Where(b => b.Qty > b.Sold);

		return (liveBatches, badBatches);
	}
}
