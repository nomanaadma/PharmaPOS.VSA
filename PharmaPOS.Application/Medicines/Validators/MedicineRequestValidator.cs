using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Medicines.Validators;

public class MedicineRequestValidator : AbstractValidator<MedicineRequest>
{
    public MedicineRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Medicine Name is required.")
            .MaximumLength(255).WithMessage("Medicine Name cannot exceed 255 characters.");

        RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Medicine Company is required.")
            .MaximumLength(255).WithMessage("Medicine Company cannot exceed 255 characters.");

        RuleFor(x => x.Generic)
            .NotEmpty().WithMessage("Medicine Generic is required.");

        RuleFor(x => x.MedicineGroup)
            .MaximumLength(255).WithMessage("Medicine Group cannot exceed 255 characters.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Please select a valid category.");

        RuleFor(x => x.StoreBox)
            .MaximumLength(255).WithMessage("Store Box cannot exceed 255 characters.");

        RuleFor(x => x.MinLevel)
            .GreaterThanOrEqualTo(0).WithMessage("Min Level must be a non-negative number.");

        RuleFor(x => x.ReOrderLevel)
            .GreaterThanOrEqualTo(0).WithMessage("Re-Order Level must be a non-negative number.");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required.")
            .MaximumLength(255).WithMessage("Unit cannot exceed 255 characters.");

        RuleFor(x => x.UnitPacking)
            .MaximumLength(255).WithMessage("Unit/Packing cannot exceed 255 characters.");
    }
}
