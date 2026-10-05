namespace PharmaPOS.Contracts.Responses;

public record BatchResponse(
	int Id,
	int MedicineId,
	int PurchaseId,
	string Name,
	string Batch,
	string Expiry,
	decimal PurchasePrice,
	decimal SalePrice,
	decimal TotalPurchase,
	decimal TotalSales,
	decimal Profit,
	decimal Qty,
	decimal Sold,
	decimal Available
);