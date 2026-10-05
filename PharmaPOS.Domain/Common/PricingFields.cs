using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.Common;

public record PricingFields(decimal Qty,
	decimal SalePrice,
	decimal Gross,
	DiscountType DiscountType,
	decimal Discount,
	decimal DiscountValue,
	decimal Tax,
	decimal TaxPrice,
	decimal Price
);