using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Categories.Validators;

public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category Name is required.")
            .MaximumLength(100).WithMessage("Category Name cannot exceed 100 characters.");
    }
}
