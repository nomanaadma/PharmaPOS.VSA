using ErrorOr;
using PharmaPOS.Domain.Common;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.CustomerAggregate;

public class Customer : AggregateRoot
{
	// EF Core parameterless constructor
	private Customer() { }

	private Customer(CustomerFields fields)
	{
		SetDetails(fields);
	}
	
	public string FirstName { get; private set; } = null!;
	public string LastName { get; private set; } = null!;
	public string? Email { get; private set; }
	public string? Mobile { get; private set; }
	public Gender? Gender { get; private set; }
	public Status Status { get; private set; }
	public DateTime CreatedDate { get; private init; }

	public static ErrorOr<Customer> Create(CustomerFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Customer(fields);
	}

	public ErrorOr<Updated> Update(CustomerFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	private void SetDetails(CustomerFields fields)
	{
		FirstName = fields.FirstName;
		LastName = fields.LastName;
		Email = fields.Email;
		Mobile = fields.Mobile;
		Gender = fields.Gender;
		Status = fields.Status;
	}

	private static List<Error> ValidateFields(CustomerFields fields)
	{
		var errors = new List<Error>();
		
		DomainValidator<Customer>.ValidateRequiredStrings(errors,
			(fields.FirstName, nameof(fields.FirstName)),
			(fields.LastName, nameof(fields.LastName))
		);
		
		// Standard DomainValidator approach
		DomainValidator<Customer>.ValidateEnums(errors,
			(fields.Gender, nameof(fields.Gender)),
			(fields.Status, nameof(fields.Status))
		);
		
		return errors;
	}
}
