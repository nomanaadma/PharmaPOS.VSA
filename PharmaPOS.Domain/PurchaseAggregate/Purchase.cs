using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.PurchaseAggregate;

public class Purchase : OrderDetails
{
	// EF Core parameterless constructor
	private Purchase() { }

	private Purchase(PurchaseFields fields)
	{
		SetDetails(fields);
	}

	public int SupplierId { get; private set; }
	
	/// <summary>
	/// Factory method: validates inputs and returns an ErrorOr&lt;Purchase&gt;.
	/// </summary>
	public static ErrorOr<Purchase> Create(PurchaseFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Purchase(fields);
	}

	/// <summary>
	/// Updates the purchase fields. Returns ErrorOr&lt;Updated&gt; with validation.
	/// </summary>
	public ErrorOr<Updated> Update(PurchaseFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}
	
	private void SetDetails(PurchaseFields fields)
	{
		SupplierId = fields.SupplierId;
		Date = fields.Date;
		SubTotal = fields.SubTotal;
		Tax = fields.Tax;
		Discount = fields.Discount;
		Amount = fields.Amount;
		Note = fields.Note;
	}

	private static List<Error> ValidateFields(PurchaseFields fields)
	{
		var errors = new List<Error>();

		DomainValidator<Purchase>.ValidateIds(errors,
			(fields.SupplierId, nameof(fields.SupplierId))
		);

		DomainValidator<Purchase>.ValidateNonNegativeNumbers(errors,
			(fields.Amount, nameof(fields.Amount)),
			(fields.SubTotal, nameof(fields.SubTotal)),
			(fields.Tax, nameof(fields.Tax)),
			(fields.Discount, nameof(fields.Discount))
		);
		
		return errors;
	}
}
