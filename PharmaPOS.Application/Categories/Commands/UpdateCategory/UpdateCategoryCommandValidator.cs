using FluentValidation;
using PharmaPOS.Application.Categories.Validators;

namespace PharmaPOS.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Category ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new CategoryRequestValidator());
    }
}
