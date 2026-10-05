using FluentValidation;
using PharmaPOS.Application.Billings.Validators;

namespace PharmaPOS.Application.Billings.Commands.UpdateBill;

public class UpdateBillCommandValidator : AbstractValidator<UpdateBillCommand>
{
    public UpdateBillCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Bill ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new BillingRequestValidator());
    }
}
