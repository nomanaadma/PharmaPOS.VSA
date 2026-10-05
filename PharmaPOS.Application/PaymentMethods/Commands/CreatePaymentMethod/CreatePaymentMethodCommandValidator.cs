using FluentValidation;
using PharmaPOS.Application.PaymentMethods.Validators;

namespace PharmaPOS.Application.PaymentMethods.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommandValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new PaymentMethodRequestValidator());
    }
}
