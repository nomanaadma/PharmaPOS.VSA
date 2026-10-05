using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Categories.Commands.CreateCategory;

[AuthorizeCommand(Permissions = Permissions.Category.Add)]
public record CreateCategoryCommand(CategoryRequest Request) : IRequest<ErrorOr<Created>>;
