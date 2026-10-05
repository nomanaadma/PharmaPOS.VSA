using FluentValidation;

namespace PharmaPOS.Application.Stock.Commands.UpdateStock;

public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Stock ID is required.");

        RuleFor(x => x.MedicineId)
            .GreaterThan(0).WithMessage("Valid Medicine ID is required.");
            
        RuleFor(x => x.Available)
            .GreaterThanOrEqualTo(0).WithMessage("Available quantity must be non-negative.");
    }
}
