using FluentValidation;
using PharmaPOS.Application.PaymentMethods.Validators;

namespace PharmaPOS.Application.PaymentMethods.Commands.UpdatePaymentMethod;

public class UpdatePaymentMethodCommandValidator : AbstractValidator<UpdatePaymentMethodCommand>
{
    public UpdatePaymentMethodCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Payment Method ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new PaymentMethodRequestValidator());
    }
}
