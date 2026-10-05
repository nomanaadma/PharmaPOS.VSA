namespace PharmaPOS.Contracts.Responses;

// public record BillingListResponse(
// 	int Id,
// 	DateTime Date,
// 	decimal SubTotal,
// 	decimal Tax,
// 	decimal Discount,
// 	decimal Amount,
// 	string? Note,
// 	string Name
// );


public record BillingListResponse
{
	public int Id { get; init; }
	public DateTime Date { get; init; }
	public decimal SubTotal { get; init; }
	public decimal Tax { get; init; }
	public decimal Discount { get; init; }
	public decimal Amount { get; init; }
	public string? Note { get; init; }
	public string Name { get; init; } = string.Empty;
}



