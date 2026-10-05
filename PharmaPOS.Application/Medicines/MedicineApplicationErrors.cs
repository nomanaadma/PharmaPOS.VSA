using ErrorOr;

namespace PharmaPOS.Application.Medicines;

public static class MedicineApplicationErrors
{
	public static readonly Error CannotDeleteWithBatches =
		Error.Conflict("Medicine.CannotDelete", "Cannot delete a medicine that has associated stock batches.");
}
