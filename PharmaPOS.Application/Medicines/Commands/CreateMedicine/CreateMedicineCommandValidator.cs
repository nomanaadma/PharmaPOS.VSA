using FluentValidation;
using PharmaPOS.Application.Medicines.Validators;

namespace PharmaPOS.Application.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
{
    public CreateMedicineCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new MedicineRequestValidator());
    }
}
