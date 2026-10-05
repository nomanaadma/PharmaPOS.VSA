using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.PaymentMethods.Validators;

public class PaymentMethodRequestValidator : AbstractValidator<PaymentMethodRequest>
{
public PaymentMethodRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Payment Method Name is required.")
            .MaximumLength(100).WithMessage("Payment Method Name cannot exceed 100 characters.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value.");
    }
}
