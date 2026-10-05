using ErrorOr;

namespace PharmaPOS.Domain.BatchAggregate;

public static class BatchErrors
{
	public static readonly Error InsufficientStock = 
		Error.Validation(
			code: "Batch.InsufficientStock", 
			description: "There is not enough stock in this batch to complete the sale.");

}