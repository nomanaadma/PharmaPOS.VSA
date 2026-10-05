using MediatR;
using PharmaPOS.Domain.MediaAggregate;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Settings.Queries.ListMedia;

[AuthorizeCommand(Permissions = Permissions.Media.List)]
public record ListMediaQuery() : IRequest<List<Media>>;
