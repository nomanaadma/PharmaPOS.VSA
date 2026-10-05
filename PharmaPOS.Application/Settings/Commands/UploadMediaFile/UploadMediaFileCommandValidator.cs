using FluentValidation;

namespace PharmaPOS.Application.Settings.Commands.UploadMediaFile;

public class UploadMediaFileCommandValidator : AbstractValidator<UploadMediaFileCommand>
{
    public UploadMediaFileCommandValidator()
    {
        RuleFor(x => x.Length)
            .GreaterThan(0).WithMessage("File cannot be empty.");

        RuleFor(x => x.OriginalFileName)
            .NotEmpty().WithMessage("File name is required.");
            
        RuleFor(x => x.FileStream)
            .NotNull().WithMessage("File stream is required.");
    }
}
