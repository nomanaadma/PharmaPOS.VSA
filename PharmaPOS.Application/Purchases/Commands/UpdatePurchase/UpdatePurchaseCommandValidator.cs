using FluentValidation;
using PharmaPOS.Application.Purchases.Validators;

namespace PharmaPOS.Application.Purchases.Commands.UpdatePurchase;

public class UpdatePurchaseCommandValidator : AbstractValidator<UpdatePurchaseCommand>
{
    public UpdatePurchaseCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Purchase ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new PurchaseRequestValidator());
    }
}
