using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Extensions;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Infrastructure.Common.Persistence;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.Batches.Persistence;

public class BatchRepository(ApplicationDbContext context) : Repository<Batch>(context), IBatchRepository
{
	private static string CurrentMonth => DateTime.UtcNow.ExpiryFormat();

	public async Task<List<Batch>> GetNonExpiredBatchesAsync(List<int> medicineIds, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => medicineIds.Contains(b.MedicineId))
			.Where(b => string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), CurrentMonth) >= 0)
			.Where(b => b.Status == Status.Active)
			.ToListAsync(ct);
	}

	public async Task<List<Batch>> GetNonExpiredBatchesAsync(int medicineId, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => b.MedicineId == medicineId)
			.Where(b => string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), CurrentMonth) >= 0)
			.Where(b => (b.Pricing.Qty - b.Sold) > 0)
			.Where(b => b.Status == Status.Active)
			.OrderBy(b => b.Expiry)
			.ToListAsync(ct);
	}

	public async Task<List<Batch>> GetActiveBatchesAsync(int medicineId, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => b.MedicineId == medicineId)
			.Where(b => b.Status == Status.Active)
			.OrderBy(b => b.MedicineId)
			.Include(batch => batch.Pricing)
			.ToListAsync(ct);
	}

	public async Task<Batch?> GetBatchAsync(int medicineId, int batchId, CancellationToken ct = default)
	{
		return await DbSet
			.Include(b => b.Pricing)
			.FirstOrDefaultAsync(b => b.MedicineId == medicineId && b.Id == batchId, ct);
	}

	public async Task<Dictionary<int, Batch>> GetBatchByIdsAsync(List<int> batchIds, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => batchIds.Contains(b.Id))
			.ToDictionaryAsync(b => b.Id, ct);
	}

	public async Task<List<Batch>> GetBatchesByPurchaseIdAsync(int purchaseId, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => b.PurchaseId == purchaseId)
			.ToListAsync(ct);
	}

	public async Task<bool> HasSoldBatchesAsync(int purchaseId, CancellationToken ct = default)
	{
		return await DbSet
			.AnyAsync(b => b.PurchaseId == purchaseId && b.Sold > 0, ct);
	}

	public async Task DeleteBatchesByPurchaseIdAsync(int purchaseId, CancellationToken ct = default)
	{
		await DbSet
			.Where(b => b.PurchaseId == purchaseId)
			.ExecuteDeleteAsync(ct);
	}

	public async Task<List<Batch>> GetActiveBatchesAsync(string? expiryFilterType = null, CancellationToken ct = default)
	{
		var query = DbSet
			.Where(b => b.Status == Status.Active);

		var filter = expiryFilterType ?? "live";

		var today = DateTime.UtcNow.Date;
		var currentMonthDate = new DateTime(today.Year, today.Month, 1);
		var currentMonthStr = currentMonthDate.ExpiryFormat();

		query = filter switch
		{
			"expired" => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) < 0),
			"willexpirein1" => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthDate.AddMonths(1).ExpiryFormat()) <= 0 && 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) >= 0),
			"willexpirein2" => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthDate.AddMonths(2).ExpiryFormat()) <= 0 && 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) >= 0),
			"willexpirein3" => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthDate.AddMonths(3).ExpiryFormat()) < 0 && 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) > 0),
			"willexpirein6" => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthDate.AddMonths(6).ExpiryFormat()) < 0 && 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) > 0),
			_ => query.Where(b => 
				string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonthStr) >= 0)
		};

		return await query.OrderBy(b => b.MedicineId).ToListAsync(ct);
	}

	public async Task AddRangeAsync(IEnumerable<Batch> batches, CancellationToken ct = default)
	{
		await DbSet.AddRangeAsync(batches, ct);
	}

	public void RemoveRange(IEnumerable<Batch> batches)
	{
		DbSet.RemoveRange(batches);
	}

	public async Task<bool> HasBatchesByMedicineAsync(int medicineId, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(b => b.MedicineId == medicineId, ct);
	}
}
