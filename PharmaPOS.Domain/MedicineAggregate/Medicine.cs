using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.MedicineAggregate;

public class Medicine : AggregateRoot
{
	
	// EF Core parameterless constructor
	private Medicine() { }

	private Medicine(MedicineFields fields)
	{
		SetDetails(fields);
	}

	public string Name { get; private set; } = null!;
	public string Company { get; private set; } = null!;
	public string Generic { get; private set; } = null!;
	public string? MedicineGroup { get; private set; }
	public int CategoryId { get; private set; }
	public string? StoreBox { get; private set; }
	public decimal? MinLevel { get; private set; }
	public decimal? ReOrderLevel { get; private set; }
	public string Unit { get; private set; } = null!;
	public string? UnitPacking { get; private set; }
	public string? Note { get; private set; }
	public DateTime CreatedDate { get; private init; }
	
	/// <summary>
	/// Factory method: validates inputs and returns an ErrorOr&lt;Medicine&gt;.
	/// </summary>
	public static ErrorOr<Medicine> Create(MedicineFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Medicine(fields);
	}

	/// <summary>
	/// Updates the medicine fields. Returns ErrorOr&lt;Updated&gt; with validation.
	/// </summary>
	public ErrorOr<Updated> Update(MedicineFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	private void SetDetails(MedicineFields fields)
	{
		Name = fields.Name;
		Company = fields.Company;
		Generic = fields.Generic;
		MedicineGroup = fields.MedicineGroup;
		CategoryId = fields.CategoryId;
		StoreBox = fields.StoreBox;
		MinLevel = fields.MinLevel;
		ReOrderLevel = fields.ReOrderLevel;
		Unit = fields.Unit;
		UnitPacking = fields.UnitPacking;
		Note = fields.Note;
	}

	private static List<Error> ValidateFields(MedicineFields fields)
	{
		var errors = new List<Error>();
		
		DomainValidator<Medicine>.ValidateRequiredStrings(errors,
			(fields.Name, nameof(fields.Name)),
			(fields.Company, nameof(fields.Company)),
			(fields.Generic, nameof(fields.Generic)),
			(fields.Unit, nameof(fields.Unit))
		);

		DomainValidator<Medicine>.ValidateIds(errors,
			(fields.CategoryId, nameof(fields.CategoryId))
		);
		

		return errors;
	}
}
