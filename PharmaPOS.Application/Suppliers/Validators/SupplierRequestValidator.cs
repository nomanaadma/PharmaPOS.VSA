using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Suppliers.Validators;

public class SupplierRequestValidator : AbstractValidator<SupplierRequest>
{
    public SupplierRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Supplier Name is required.")
            .MaximumLength(150).WithMessage("Supplier Name cannot exceed 150 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid Email Address.")
            .MaximumLength(254).WithMessage("Email Address cannot exceed 254 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone Number is required.")
            .MaximumLength(30).WithMessage("Phone Number cannot exceed 30 characters.");

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Address cannot exceed 500 characters.");
    }
}
