namespace PharmaPOS.Contracts.Responses;

public record BillEditResponse : BillResponse 
{
	public new IReadOnlyCollection<BillEditItemDto> Items { get; init; } = [];
}

public record BillEditItemDto : BillItemDto
{
	public IReadOnlyCollection<BillEditBatchDto> Batches { get; set; } = [];
}

public record BillEditBatchDto
{
	public int Id { get; init; }
	public decimal Qty { get; init; }
	public string BatchName { get; init; } = "";
	public decimal Sold { get; init; }
}
