namespace PharmaPOS.Contracts.Requests;

public record OrderDetailsRequest<T>(
	int Id,
	DateTime Date,
	string? Note,
	decimal SubTotal,
	decimal Tax,
	decimal Discount,
	decimal Amount,
	List<T> Items
);

