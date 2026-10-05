using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Requests;

public record PaymentMethodRequest(
	int Id,
	string Name,
	Status Status
);