namespace PharmaPOS.Contracts.Responses;

public record StatsReportResponse
(
	DateTime StartDate,
	DateTime EndDate,
	int? MedicineId,
	string? MedicineName,
	decimal SalesAmount,
	decimal PurchaseAmount,
	decimal? Quantity,
	decimal TaxAmount,
	decimal DiscountAmount,
	decimal Profit
);