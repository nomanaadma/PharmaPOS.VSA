namespace PharmaPOS.Contracts.Requests;

public record SupplierRequest(
	int Id,
	string Name,
	string Email,
	string Phone,
	string? Address
);