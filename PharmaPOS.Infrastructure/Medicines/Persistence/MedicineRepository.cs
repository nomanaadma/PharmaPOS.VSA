using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.MedicineAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.Medicines.Persistence;

public class MedicineRepository(
	ApplicationDbContext context) : Repository<Medicine>(context), IMedicineRepository
{
	public async Task<List<(Medicine medicine, decimal liveStock)>> GetMedicinesWithStockAsync(CancellationToken ct = default)
	{
		var currentMonth = DateTime.UtcNow.ToString("yyyyMM");

		var medicines = await DbSet
			.OrderByDescending(m => m.CreatedDate)
			.Select(m => new {
				medicine = m,
				liveStock = DbContext.Batches
					.Where(b => b.MedicineId == m.Id)
					.Where(b => b.Status == Status.Active && string.Compare(b.Expiry.Substring(3, 4) + b.Expiry.Substring(0, 2), currentMonth) >= 0)
					.Sum(b => (decimal?)(b.Pricing.Qty - b.Sold)) ?? 0m
			})
			.ToListAsync(ct);

		return medicines
			.Select(x => (x.medicine, x.liveStock))
			.ToList();
		
	}

	public async Task<Dictionary<int, string>> GetMedicineNamesByIdsAsync(List<int> medicineIds, CancellationToken ct = default)
	{
		return await DbSet
			.Where(m => medicineIds.Contains(m.Id))
			.ToDictionaryAsync(m => m.Id, m => m.Name, ct);
	}

	public async Task<List<MedicineSearchResult>> SearchMedicinesAsync(string term, int take = 10, CancellationToken ct = default)
	{
		return await DbSet
			.Where(m => EF.Functions.ILike(m.Name, $"%{term}%"))
			.Take(take)
			.Select(m => new MedicineSearchResult
			(
				m.Id,
				m.Name,
				m.Generic
			))
			.ToListAsync(ct);
	}
}
