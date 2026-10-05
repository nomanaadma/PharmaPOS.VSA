namespace PharmaPOS.Domain.Common;

public class OutboxMessage
{
	public Guid Id { get; set; }
	public required string Type { get; set; }
	public required string Content { get; set; }
	public DateTime OccurredOn { get; set; }
	public DateTime? ProcessedOn { get; set; }
	public string? Error { get; set; }
	public int RetryCount { get; set; }
}
