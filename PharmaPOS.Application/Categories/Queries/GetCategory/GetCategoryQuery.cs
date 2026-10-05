using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Categories.Queries.GetCategory;

[AuthorizeCommand(Permissions = Permissions.Category.Edit)]
public record GetCategoryQuery(int Id) : IRequest<ErrorOr<CategoryResponse>>;
