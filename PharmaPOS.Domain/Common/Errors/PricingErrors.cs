using ErrorOr;

namespace PharmaPOS.Domain.Common.Errors;

public static class PricingErrors
{
	public static Error NegativeQuantity =>
		Error.Validation("Pricing.NegativeQuantity", "Quantity cannot be negative.");

	public static Error NegativeSalePrice =>
		Error.Validation("Pricing.NegativeSalePrice", "Sale Price cannot be negative.");
}
