namespace PharmaPOS.Contracts.Responses;

public record MedicineResponse(
	int Id,
	string Name,
	string Company,
	string Generic,
	string? MedicineGroup,
	int CategoryId,
	string? CategoryName,
	string? StoreBox,
	decimal? MinLevel,
	decimal? ReOrderLevel,
	string Unit,
	string? UnitPacking,
	string? Note,
	DateTime? CreatedDate,
	decimal? LiveStock
);