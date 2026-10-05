namespace PharmaPOS.Domain.BillingAggregate;

public record BillFields(int CustomerId, string Name, string? Email, string? Mobile, int MethodId, DateTime BillDate, decimal SubTotal, decimal Tax, decimal Discount, decimal Amount, string? Note);
