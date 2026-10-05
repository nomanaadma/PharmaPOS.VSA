namespace PharmaPOS.Contracts.Requests;

public record PurchaseRequest(
	int Id,
	DateTime Date,
	string? Note,
	decimal SubTotal,
	decimal Tax,
	decimal Discount,
	decimal Amount,
	List<PurchaseItemRequest> Items,
	int Supplier
) : OrderDetailsRequest<PurchaseItemRequest>(Id, Date, Note, SubTotal, Tax, Discount, Amount, Items);

