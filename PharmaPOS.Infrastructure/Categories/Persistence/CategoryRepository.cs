using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.CategoryAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Categories.Persistence;

public class CategoryRepository(ApplicationDbContext context) : Repository<Category>(context), ICategoryRepository
{
	public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(c => c.Name == name && (!excludeId.HasValue || c.Id != excludeId.Value), ct);
	}

	public async Task<List<LookupItem>> GetLookupListAsync(CancellationToken ct = default)
	{
		return await DbSet
			.OrderBy(c => c.Name)
			.Select(c => new LookupItem(c.Id.ToString(), c.Name))
			.ToListAsync(ct);
	}
	
	public async Task<string?> GetCategoryNameByIdAsync(int id, CancellationToken ct = default)
	{
		return await DbSet
			.Where(c => c.Id == id)
			.Select(c => c.Name)
			.FirstOrDefaultAsync(ct);
	}
	
	public async Task<Dictionary<int, string>> GetCategoryNamesByIdsAsync(List<int> categoryIds, CancellationToken ct = default)
	{
		return await DbSet
			.Where(m => categoryIds.Contains(m.Id))
			.ToDictionaryAsync(m => m.Id, m => m.Name, ct);
	}
	
}
