using PharmaPOS.Domain.MediaAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IMediaRepository : IRepository<Media>
{
	Task<List<Media>> GetMediaListAsync(CancellationToken ct = default);
	Task<Media?> GetByIdAndFilenameAsync(int id, string filename, CancellationToken ct = default);
}
