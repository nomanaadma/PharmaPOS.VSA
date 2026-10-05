using FluentValidation;
using PharmaPOS.Application.Medicines.Validators;

namespace PharmaPOS.Application.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineCommandValidator : AbstractValidator<UpdateMedicineCommand>
{
    public UpdateMedicineCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Medicine ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new MedicineRequestValidator());
    }
}
