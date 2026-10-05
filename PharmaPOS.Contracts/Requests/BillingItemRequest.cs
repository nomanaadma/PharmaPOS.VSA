using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Requests;

public record BillingItemRequest(
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
	int Batch,
	string BatchName,
	List<BillingItemBatchesRequest> Batches
) : PricingDetailRequest(Id, MedicineId, Name, Expiry, Qty, SalePrice, Gross, DiscountType, Discount, DiscountValue, Tax, TaxPrice, Price);

