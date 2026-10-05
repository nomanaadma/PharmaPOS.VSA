namespace PharmaPOS.Contracts.Responses;

public record SupplierResponse(int Id,
	string Name,
	string Email,
	string Phone,
	string? Address
);
