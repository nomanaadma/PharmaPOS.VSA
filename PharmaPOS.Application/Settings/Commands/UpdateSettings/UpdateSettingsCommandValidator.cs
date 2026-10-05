using FluentValidation;

namespace PharmaPOS.Application.Settings.Commands.UpdateSettings;

public class UpdateSettingsCommandValidator : AbstractValidator<UpdateSettingsCommand>
{
    public UpdateSettingsCommandValidator()
    {
        RuleFor(x => x.Request.Name)
            .NotEmpty().WithMessage("Store Name is required.");

        RuleFor(x => x.Request.LegalName)
            .NotEmpty().WithMessage("Store Legal Name is required.");

        RuleFor(x => x.Request.Mail)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid Email Address.");

        RuleFor(x => x.Request.Phone)
            .NotEmpty().WithMessage("Phone Number is required.");
    }
}
