using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.PaymentMethodAggregate;

public record PaymentMethodFields(string Name, Status Status);
