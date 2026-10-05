using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Requests;

public record CustomerRequest(
	int? Id,
	string FirstName,
	string LastName,
	string? Email,
	string? Mobile,
	Gender Gender,
	Status Status
);
