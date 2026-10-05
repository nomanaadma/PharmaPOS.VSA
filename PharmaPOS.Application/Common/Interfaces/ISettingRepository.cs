using PharmaPOS.Domain.SettingAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface ISettingRepository : IRepository<Setting>
{
	Task<Setting?> GetRawSettingsAsync(CancellationToken ct = default);
	Task<Setting?> GetSettingsAsync(CancellationToken ct = default);
}
