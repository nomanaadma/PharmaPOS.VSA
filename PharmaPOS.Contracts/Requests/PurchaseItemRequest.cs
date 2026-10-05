using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Requests;

public record PurchaseItemRequest(
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
	decimal Price,
	string Batch,
	string? Pqty,
	decimal Purchaseprice
) : PricingDetailRequest(Id, MedicineId, Name, Expiry, Qty, SalePrice, Gross, DiscountType, Discount, DiscountValue, Tax, TaxPrice, Price);