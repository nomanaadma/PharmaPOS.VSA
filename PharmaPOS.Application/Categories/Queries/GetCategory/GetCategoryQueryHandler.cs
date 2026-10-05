using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.CategoryAggregate;

namespace PharmaPOS.Application.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler(
	ICategoryRepository categoryRepo) : IRequestHandler<GetCategoryQuery, ErrorOr<CategoryResponse>>
{
	public async Task<ErrorOr<CategoryResponse>> Handle(GetCategoryQuery query, CancellationToken ct)
	{
		var category = await categoryRepo.GetByIdAsync(query.Id, ct);
		if (category == null)
			return CommonErrors<Category>.NotFound(query.Id);

		var categoryResponse = category.Adapt<CategoryResponse>();
		return categoryResponse;
	}
}

