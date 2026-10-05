using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.SupplierAggregate;

public class Supplier : AggregateRoot
{
	// EF Core parameterless constructor
	private Supplier() { }

	private Supplier(SupplierFields fields)
	{
		SetDetails(fields);
	}

	public string Name { get; private set; } = null!;
	public string Email { get; private set; } = null!;
	public string Phone { get; private set; } = null!;
	public string? Address { get; private set; }
	public DateTime CreatedDate { get; private init; }


	public static ErrorOr<Supplier> Create(SupplierFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Supplier(fields);
	}

	public ErrorOr<Updated> Update(SupplierFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	private void SetDetails(SupplierFields fields)
	{
		Name = fields.Name;
		Email = fields.Email;
		Phone = fields.Phone;
		Address = fields.Address;
	}

	private static List<Error> ValidateFields(SupplierFields fields)
	{
		var errors = new List<Error>();

		DomainValidator<Supplier>.ValidateRequiredStrings(errors,
			(fields.Name, nameof(fields.Name)),
			(fields.Email, nameof(fields.Email)),
			(fields.Phone, nameof(fields.Phone))
		);

		return errors;
	}
}
