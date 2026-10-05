using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Settings.Commands.DeleteMediaFile;

[AuthorizeCommand(Permissions = Permissions.Media.Delete)]
public record DeleteMediaFileCommand(int Id, string Name) : IRequest<ErrorOr<Deleted>>;
