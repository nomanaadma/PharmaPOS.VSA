using FluentValidation;
using PharmaPOS.Application.Suppliers.Validators;

namespace PharmaPOS.Application.Suppliers.Commands.UpdateSupplier;

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Supplier ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new SupplierRequestValidator());
    }
}
