namespace PharmaPOS.Contracts.Responses;

public record PurchaseResponse(
	int Id,
	int Supplier,
	DateTime Date,
	string? Note,
	decimal SubTotal,
	decimal Tax,
	decimal Discount,
	decimal Amount,
	IReadOnlyCollection<PurchaseItemResponse> Items,
	string? SupplierName,
	string? SupplierEmail,
	string? SupplierPhone
);

public record PurchaseItemResponse(
	int Id,
	int MedicineId,
	string Batch,
	string Expiry,
	string? Pqty,
	decimal Purchaseprice
) : PricingDto
{
	public string Name { get; set; } = "";
}