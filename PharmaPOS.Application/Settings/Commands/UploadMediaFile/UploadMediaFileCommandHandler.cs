using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.MediaAggregate;

namespace PharmaPOS.Application.Settings.Commands.UploadMediaFile;

public class UploadMediaFileCommandHandler(
	IMediaRepository mediaRepo,
	IUnitOfWork unitOfWork,
	IFilePathProvider pathProvider) : IRequestHandler<UploadMediaFileCommand, ErrorOr<MediaUploadResponse>>
{
	public async Task<ErrorOr<MediaUploadResponse>> Handle(UploadMediaFileCommand command, CancellationToken ct)
	{
		var ext = Path.GetExtension(command.OriginalFileName).TrimStart('.').ToLower();
		var uniqueId = Guid.NewGuid().ToString("N")[..8];
		var fileName = $"media-{uniqueId}.{ext}";
		var filePath = pathProvider.GetUploadsFilePath(fileName);

		await using (var destinationStream = new FileStream(filePath, FileMode.Create))
		{
			await command.FileStream.CopyToAsync(destinationStream, ct);
		}

		var mediaResult = Media.Create(fileName, ext, DateTime.UtcNow);
		if (mediaResult.IsError)
			return mediaResult.Errors;

		var media = mediaResult.Value;
		await mediaRepo.AddAsync(media, ct);
		await unitOfWork.SaveChangesAsync(ct);

		var (width, height) = ImageHelper.GetImageDimensions(filePath);

		return new MediaUploadResponse(media.Id, media.Filename, width, height);
	}
}
