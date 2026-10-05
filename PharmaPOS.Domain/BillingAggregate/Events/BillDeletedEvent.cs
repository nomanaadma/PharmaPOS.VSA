using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.BillingAggregate.Events;

public record BillDeletedEvent(int CustomerId) : IAsyncDomainEvent;
