using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Responses;

public record PaymentMethodResponse(int Id,
	string Name,
	Status Status
);