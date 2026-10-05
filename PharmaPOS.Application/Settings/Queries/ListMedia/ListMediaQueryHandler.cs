using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.MediaAggregate;

namespace PharmaPOS.Application.Settings.Queries.ListMedia;

public class ListMediaQueryHandler(
	IMediaRepository mediaRepo) : IRequestHandler<ListMediaQuery, List<Media>>
{
	public async Task<List<Media>> Handle(ListMediaQuery query, CancellationToken ct)
	{
		return await mediaRepo.GetMediaListAsync(ct);
	}
}
