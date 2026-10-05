using ErrorOr;

namespace PharmaPOS.Application.Billings;

public static class BillApplicationErrors
{
    public static Error BatchNotFound(int batchId, int medicineId) =>
        Error.NotFound("Bill.BatchNotFound", $"Batch {batchId} not found for Medicine {medicineId}.");
    
    public static Error InsufficientStock(string batchName, decimal available, decimal requested) =>
        Error.Validation("Bill.InsufficientStock",
            $"Insufficient stock for batch {batchName}. Available: {available}, Requested: {requested}");
    
}
