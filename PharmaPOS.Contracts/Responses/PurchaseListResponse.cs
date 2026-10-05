namespace PharmaPOS.Contracts.Responses;

public record PurchaseListResponse
{
	public int Id { get; init; }
	public DateTime Date { get; init; }
	public decimal SubTotal { get; init; }
	public decimal Tax { get; init; }
	public decimal Discount { get; init; }
	public decimal Amount { get; init; }
	public string? Note { get; init; }
	public string SupplierName { get; init; } = string.Empty;
}

