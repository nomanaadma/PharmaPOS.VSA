using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Categories.Queries.ListCategoriesLookup;

public class ListCategoriesLookupQueryHandler(
	ICategoryRepository categoryRepo) : IRequestHandler<ListCategoriesLookupQuery, IEnumerable<LookupItem>>
{
	public async Task<IEnumerable<LookupItem>> Handle(ListCategoriesLookupQuery query, CancellationToken ct)
	{
		return await categoryRepo.GetLookupListAsync(ct);
	}
}
