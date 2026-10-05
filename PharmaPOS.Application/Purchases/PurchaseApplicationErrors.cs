using ErrorOr;

namespace PharmaPOS.Application.Purchases;

public static class PurchaseApplicationErrors
{
    public static readonly Error CannotDeleteSoldPurchase =
	    Error.Conflict("Batch.CannotDeletePurchaseWithSoldBatches", "Cannot delete purchase because one or more batches have already been sold.");
    
    public static Error CannotDelete(string batchName) =>
	    Error.Conflict("Batch.CannotDeleteSoldBatch", $"Cannot delete batch '{batchName}' because it has already been sold.");
    
    public static Error CannotUpdate(string batchName, decimal qty, decimal sold) =>
	    Error.Conflict("Batch.CannotUpdateSoldQuantity", $"Cannot update batch '{batchName}'. New quantity ({qty}) is less than the amount already sold ({sold}).");
    
}
