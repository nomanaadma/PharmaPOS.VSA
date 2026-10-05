using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Settings.Commands.UploadMediaFile;

[AuthorizeCommand(Permissions = Permissions.Media.Upload)]
public record UploadMediaFileCommand(Stream FileStream, string OriginalFileName, long Length) : IRequest<ErrorOr<MediaUploadResponse>>;
