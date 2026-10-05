namespace PharmaPOS.Contracts.Requests;

public record BillingItemBatchesRequest(
	int Id,
	decimal Qty,
	decimal Sold,
	string Batch
);