namespace PharmaPOS.Contracts.Responses;

public record CustomerBillsResponse(
	int Id,
	decimal Amount,
	DateTime BillDate
);