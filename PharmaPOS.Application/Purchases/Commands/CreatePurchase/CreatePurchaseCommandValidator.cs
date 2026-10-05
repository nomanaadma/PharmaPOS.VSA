using FluentValidation;
using PharmaPOS.Application.Purchases.Validators;

namespace PharmaPOS.Application.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new PurchaseRequestValidator());
    }
}
