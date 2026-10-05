using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IBatchRepository : IRepository<Batch>
{
	Task<List<Batch>> GetNonExpiredBatchesAsync(List<int> medicineIds, CancellationToken ct = default);
	Task<List<Batch>> GetNonExpiredBatchesAsync(int medicineId, CancellationToken ct = default);
	Task<List<Batch>> GetActiveBatchesAsync(int medicineId, CancellationToken ct = default);
	Task<Batch?> GetBatchAsync(int medicineId, int batchId, CancellationToken ct = default);
	Task<Dictionary<int, Batch>> GetBatchByIdsAsync(List<int> batchIds, CancellationToken ct = default);
	Task<List<Batch>> GetBatchesByPurchaseIdAsync(int purchaseId, CancellationToken ct = default);
	Task<bool> HasSoldBatchesAsync(int purchaseId, CancellationToken ct = default);
	Task DeleteBatchesByPurchaseIdAsync(int purchaseId, CancellationToken ct = default);
	Task<List<Batch>> GetActiveBatchesAsync(string? expiryFilterType = null, CancellationToken ct = default);
	Task AddRangeAsync(IEnumerable<Batch> batches, CancellationToken ct = default);
	void RemoveRange(IEnumerable<Batch> batches);
	Task<bool> HasBatchesByMedicineAsync(int medicineId, CancellationToken ct = default);
}
