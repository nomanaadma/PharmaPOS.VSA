using PharmaPOS.Domain.Common.ValueObjects;

namespace PharmaPOS.Domain.BillingAggregate;

public record BillItemFields(int MedicineId, int BatchId, PricingDetails Pricing);
