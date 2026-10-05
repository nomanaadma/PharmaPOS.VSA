using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Responses;

public record CustomerResponse(
	int Id,
	string FirstName,
	string LastName,
	string? Email,
	string? Mobile,
	Gender? Gender,
	Status Status,
	DateTime? CreatedDate
);

