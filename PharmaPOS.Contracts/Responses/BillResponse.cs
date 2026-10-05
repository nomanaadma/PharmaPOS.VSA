namespace PharmaPOS.Contracts.Responses;

public record BillResponse
{
	public int Id { get; init; }
	public int CustomerId { get; init; }
	public string Name { get; init; } = "";
	public string? Email { get; init; }
	public string? Mobile { get; init; }
	public int MethodId { get; init; }
	public string PaymentMethodName { get; set; } = "";
	public DateTime Date { get; init; }
	public decimal SubTotal { get; init; }
	public decimal Tax { get; init; }
	public decimal Discount { get; init; }
	public decimal Amount { get; init; }
	public string? Note { get; init; }

	public IReadOnlyCollection<BillItemDto> Items { get; init; } = [];
}

public record BillItemDto : PricingDto
{
	public int Id { get; init; }
	public int MedicineId { get; init; }
	public string MedicineName { get; set; } = "";
	public int BatchId { get; set; }
	public string BatchName { get; set; } = "";
	public string Expiry { get; set; } = "";
}


