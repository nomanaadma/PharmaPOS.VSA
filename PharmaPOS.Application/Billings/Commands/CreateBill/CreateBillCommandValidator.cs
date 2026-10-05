using FluentValidation;
using PharmaPOS.Application.Billings.Validators;

namespace PharmaPOS.Application.Billings.Commands.CreateBill;

public class CreateBillCommandValidator : AbstractValidator<CreateBillCommand>
{
    public CreateBillCommandValidator()
    {
        RuleFor(x => x.Request).SetValidator(new BillingRequestValidator());
    }
}
