using ErrorOr;

namespace PharmaPOS.Domain.BillingAggregate;

public static class BillErrors
{
	
	public static readonly Error InvalidMedicine =
		Error.Validation("BillItem.InvalidMedicine", "Valid Medicine is required.");
    
	public static readonly Error InvalidBatch =
		Error.Validation("BillItem.InvalidBatch", "Valid Batch is required.");
	
}
