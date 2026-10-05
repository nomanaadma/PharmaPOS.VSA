using FluentValidation;
using PharmaPOS.Application.Suppliers.Validators;

namespace PharmaPOS.Application.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new SupplierRequestValidator());
    }
}
