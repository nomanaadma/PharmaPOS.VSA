using FluentValidation;
using PharmaPOS.Application.Customers.Validators;

namespace PharmaPOS.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new CustomerRequestValidator());
    }
}
