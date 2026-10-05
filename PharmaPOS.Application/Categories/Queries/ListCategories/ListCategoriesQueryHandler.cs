using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Categories.Queries.ListCategories;

public class ListCategoriesQueryHandler(
	ICategoryRepository categoryRepo) : IRequestHandler<ListCategoriesQuery, List<CategoryResponse>>
{
	public async Task<List<CategoryResponse>> Handle(ListCategoriesQuery query, CancellationToken ct)
	{
		var categories = await categoryRepo.GetAllAsync(ct);
		var categoriesResponse = categories.Adapt<List<CategoryResponse>>();
		return categoriesResponse;
	}
}
