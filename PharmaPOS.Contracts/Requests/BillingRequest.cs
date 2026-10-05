namespace PharmaPOS.Contracts.Requests;

public record BillingRequest(
	int Id,
	DateTime Date,
	string? Note,
	decimal SubTotal,
	decimal Tax,
	decimal Discount,
	decimal Amount,
	List<BillingItemRequest> Items,
	int? CustomerId,
	string Name,
	string? Email,
	string? Mobile,
	int Method
) : OrderDetailsRequest<BillingItemRequest>(Id, Date, Note, SubTotal, Tax, Discount, Amount, Items);