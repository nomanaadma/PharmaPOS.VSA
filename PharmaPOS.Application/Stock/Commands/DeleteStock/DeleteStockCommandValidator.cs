using FluentValidation;

namespace PharmaPOS.Application.Stock.Commands.DeleteStock;

public class DeleteStockCommandValidator : AbstractValidator<DeleteStockCommand>
{
    public DeleteStockCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Stock ID is required.");
    }
}
