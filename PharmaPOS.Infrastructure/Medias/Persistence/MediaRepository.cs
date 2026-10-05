using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.MediaAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Medias.Persistence;

public class MediaRepository(ApplicationDbContext context) : Repository<Media>(context), IMediaRepository
{
	public async Task<List<Media>> GetMediaListAsync(CancellationToken ct = default)
	{
		return await DbSet.OrderBy(m => m.CreatedDate).ToListAsync(ct);
	}

	public async Task<Media?> GetByIdAndFilenameAsync(int id, string filename, CancellationToken ct = default)
	{
		return await DbSet.FirstOrDefaultAsync(m => m.Id == id && m.Filename == filename, ct);
	}
}
