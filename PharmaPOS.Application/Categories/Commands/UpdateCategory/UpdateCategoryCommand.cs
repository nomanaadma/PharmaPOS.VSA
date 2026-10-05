using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Categories.Commands.UpdateCategory;

[AuthorizeCommand(Permissions = Permissions.Category.Edit)]
public record UpdateCategoryCommand(int Id, CategoryRequest Request) : IRequest<ErrorOr<Updated>>;
