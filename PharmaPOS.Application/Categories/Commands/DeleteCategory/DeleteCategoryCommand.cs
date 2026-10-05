using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Categories.Commands.DeleteCategory;

[AuthorizeCommand(Permissions = Permissions.Category.Delete)]
public record DeleteCategoryCommand(int Id) : IRequest<ErrorOr<Deleted>>;
