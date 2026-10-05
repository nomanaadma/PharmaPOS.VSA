using FluentValidation;
using PharmaPOS.Application.Customers.Validators;

namespace PharmaPOS.Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Valid Customer ID is required for update.");
            
        RuleFor(x => x.Request)
            .SetValidator(new CustomerRequestValidator());
    }
}
