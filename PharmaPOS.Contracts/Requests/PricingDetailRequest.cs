using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Requests;

public record PricingDetailRequest(
	int Id,
	int MedicineId,
	string Name,
	string Expiry,
	decimal Qty,
	decimal SalePrice,
	decimal Gross,
	DiscountType DiscountType,
	decimal Discount,
	decimal DiscountValue,
	decimal Tax,
	decimal TaxPrice,
	decimal Price
);