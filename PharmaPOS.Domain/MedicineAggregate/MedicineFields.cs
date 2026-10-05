namespace PharmaPOS.Domain.MedicineAggregate;

public record MedicineFields(
	string Name,
	string Company,
	string Generic,
	string? MedicineGroup,
	int CategoryId,
	string? StoreBox,
	decimal? MinLevel,
	decimal? ReOrderLevel,
	string Unit,
	string? UnitPacking,
	string? Note);