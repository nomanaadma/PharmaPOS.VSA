namespace PharmaPOS.Contracts.Responses;

public record InventoryReportResponse(
	int MedicineId,
	string MedicineName,
	decimal? ReorderLevel,
	decimal? MinLevel,
	decimal TotalPurchase,
	decimal TotalSales,
	decimal LiveStock
)
{
	public decimal Profit { get; set; }
};
