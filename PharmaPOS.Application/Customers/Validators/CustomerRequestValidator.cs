using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Customers.Validators;

public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
{
    public CustomerRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(100).WithMessage("First Name cannot exceed 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(100).WithMessage("Last Name cannot exceed 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid Email Address.")
            .MaximumLength(254).WithMessage("Email Address cannot exceed 254 characters.");

        RuleFor(x => x.Mobile)
            .NotEmpty().WithMessage("Mobile Number is required.")
            .MaximumLength(30).WithMessage("Mobile Number cannot exceed 30 characters.");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Invalid gender value.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value.");
    }
}
