using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.SettingAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Settings.Persistence;

public class SettingRepository(ApplicationDbContext context) : Repository<Setting>(context), ISettingRepository
{
	public async Task<Setting?> GetRawSettingsAsync(CancellationToken ct = default)
	{
		return await DbSet.FirstOrDefaultAsync(ct);
	}

	public async Task<Setting?> GetSettingsAsync(CancellationToken ct = default)
	{
		return await DbSet.AsNoTracking().OrderBy(s => s.Id).FirstOrDefaultAsync(ct);
	}
}
