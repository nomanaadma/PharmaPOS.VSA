using FluentValidation;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Shared.Enums;
using System;

namespace PharmaPOS.Application.Billings.Validators;

public class BillingItemRequestValidator : AbstractValidator<BillingItemRequest>
{
    public BillingItemRequestValidator()
    {
        RuleFor(x => x).Custom((item, context) =>
        {
            var tolerance = 0.02m;

            var expectedGross = Math.Round(item.Qty * item.SalePrice, 2, MidpointRounding.AwayFromZero);
            if (Math.Abs(item.Gross - expectedGross) > tolerance)
                context.AddFailure(nameof(item.Gross), $"Calculated Gross ({expectedGross}) does not match provided Gross ({item.Gross}).");

            var expectedDiscountValue = item.DiscountType == DiscountType.Flat 
                ? Math.Round(item.Discount, 2, MidpointRounding.AwayFromZero) 
                : Math.Round(expectedGross * item.Discount * 0.01m, 2, MidpointRounding.AwayFromZero);
            
            if (Math.Abs(item.DiscountValue - expectedDiscountValue) > tolerance)
                context.AddFailure(nameof(item.DiscountValue), $"Calculated Discount ({expectedDiscountValue}) does not match provided ({item.DiscountValue}).");

            var grossAfterDiscount = expectedGross - expectedDiscountValue;
            var expectedTaxPrice = Math.Round(grossAfterDiscount * item.Tax * 0.01m, 2, MidpointRounding.AwayFromZero);

            if (Math.Abs(item.TaxPrice - expectedTaxPrice) > tolerance)
                context.AddFailure(nameof(item.TaxPrice), $"Calculated Tax ({expectedTaxPrice}) does not match provided ({item.TaxPrice}).");

            var expectedPrice = grossAfterDiscount + expectedTaxPrice;
            if (expectedPrice < 0) expectedPrice = 0;

            if (Math.Abs(item.Price - expectedPrice) > tolerance)
                context.AddFailure(nameof(item.Price), $"Calculated Price ({expectedPrice}) does not match provided Price ({item.Price}).");
        });
    }
}
