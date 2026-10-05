using ErrorOr;
using PharmaPOS.Domain.Common;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.PaymentMethodAggregate;

public class PaymentMethod : AggregateRoot
{
	// EF Core parameterless constructor
	private PaymentMethod() { }

	private PaymentMethod(PaymentMethodFields fields)
	{
		SetDetails(fields);
	}

	public string Name { get; private set; } = null!;
	public Status Status { get; private set; }
	public DateTime CreatedDate { get; private init; }


	public static ErrorOr<PaymentMethod> Create(PaymentMethodFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new PaymentMethod(fields);
	}

	public ErrorOr<Updated> Update(PaymentMethodFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	private void SetDetails(PaymentMethodFields fields)
	{
		Name = fields.Name;
		Status = fields.Status;
	}

	private static List<Error> ValidateFields(PaymentMethodFields fields)
	{
		var errors = new List<Error>();

		DomainValidator<PaymentMethod>.ValidateRequiredStrings(errors,
			(fields.Name, nameof(fields.Name))
		);

		DomainValidator<PaymentMethod>.ValidateEnums(errors,
			(fields.Status, nameof(fields.Status))
		);

		return errors;
	}
}
