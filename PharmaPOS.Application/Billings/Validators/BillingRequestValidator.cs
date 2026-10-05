using FluentValidation;
using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Application.Billings.Validators;

public class BillingRequestValidator : AbstractValidator<BillingRequest>
{
    public BillingRequestValidator()
    {
        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid Email Address")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Bill must have at least one item.");
            
        RuleForEach(x => x.Items)
            .SetValidator(new BillingItemRequestValidator());
            
        RuleFor(x => x).Custom((request, context) =>
        {
            var tolerance = 0.05m; // Slightly higher tolerance for aggregates

            var expectedSubTotal = Math.Round(request.Items.Sum(i => i.Gross), 2, MidpointRounding.AwayFromZero);
            if (Math.Abs(request.SubTotal - expectedSubTotal) > tolerance)
                context.AddFailure(nameof(request.SubTotal), $"Calculated SubTotal ({expectedSubTotal}) does not match provided ({request.SubTotal}).");

            var expectedTax = Math.Round(request.Items.Sum(i => i.TaxPrice), 2, MidpointRounding.AwayFromZero);
            if (Math.Abs(request.Tax - expectedTax) > tolerance)
                context.AddFailure(nameof(request.Tax), $"Calculated Tax ({expectedTax}) does not match provided ({request.Tax}).");

            var expectedDiscount = Math.Round(request.Items.Sum(i => i.DiscountValue), 2, MidpointRounding.AwayFromZero);
            if (Math.Abs(request.Discount - expectedDiscount) > tolerance)
                context.AddFailure(nameof(request.Discount), $"Calculated Discount ({expectedDiscount}) does not match provided ({request.Discount}).");

            var expectedAmount = expectedSubTotal - expectedDiscount + expectedTax;
            if (expectedAmount < 0) expectedAmount = 0;

            if (Math.Abs(request.Amount - expectedAmount) > tolerance)
                context.AddFailure(nameof(request.Amount), $"Calculated Amount ({expectedAmount}) does not match provided ({request.Amount}).");
        });
    }
}
