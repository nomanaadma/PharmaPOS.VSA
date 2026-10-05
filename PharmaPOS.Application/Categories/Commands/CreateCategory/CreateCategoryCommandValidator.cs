using FluentValidation;
using PharmaPOS.Application.Categories.Validators;

namespace PharmaPOS.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new CategoryRequestValidator());
    }
}
