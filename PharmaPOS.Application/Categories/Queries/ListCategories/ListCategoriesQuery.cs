using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Categories.Queries.ListCategories;

[AuthorizeCommand(Permissions = Permissions.Category.List)]
public record ListCategoriesQuery : IRequest<List<CategoryResponse>>;
