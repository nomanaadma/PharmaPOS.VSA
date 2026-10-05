using ErrorOr;
using PharmaPOS.Domain.BillingAggregate.Events;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.BillingAggregate;

public class Bill : OrderDetails
{
	private readonly List<BillItem> _items = [];

	// EF Core parameterless constructor
	private Bill() { }

	private Bill(BillFields fields)
	{
		SetDetails(fields);
	}

	public int CustomerId { get; private set; }
	public string Name { get; private set; } = null!;
	public string? Email { get; private set; }
	public string? Mobile { get; private set; }
	public int MethodId { get; private set; }

	public IReadOnlyCollection<BillItem> Items => _items.AsReadOnly();

	/// <summary>
	/// Factory method: validates inputs and returns an ErrorOr&lt;Bill&gt;.
	/// </summary>
	public static ErrorOr<Bill> Create(BillFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Bill(fields);
	}

	/// <summary>
	/// Updates the bill fields. Returns ErrorOr&lt;Updated&gt; with validation.
	/// </summary>
	public ErrorOr<Updated> Update(BillFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	public ErrorOr<Success> AddItem(BillItemFields billItemFields)
	{
		var itemResult = BillItem.Create(billItemFields);
		
		if (itemResult.IsError)
			return itemResult.Errors;
		
		_items.Add(itemResult.Value);
		
		return Result.Success;
		
	}

	public void ClearItems()
	{
		_items.Clear();
	}

	public void Delete()
	{
		RaiseDomainEvent(new BillDeletedEvent(CustomerId));
	}

	private void SetDetails(BillFields fields)
	{
		CustomerId = fields.CustomerId;
		Name = fields.Name;
		Email = fields.Email;
		Mobile = fields.Mobile;
		MethodId = fields.MethodId;
		Date = fields.BillDate;
		SubTotal = fields.SubTotal;
		Tax = fields.Tax;
		Discount = fields.Discount;
		Amount = fields.Amount;
		Note = fields.Note;
	}

	private static List<Error> ValidateFields(BillFields fields)
	{
		var errors = new List<Error>();
		
		DomainValidator<Bill>.ValidateRequiredStrings(errors,
			(fields.Name, nameof(fields.Name))
		);
		
		DomainValidator<Bill>.ValidateIds(errors,
			(fields.CustomerId, nameof(fields.CustomerId)),
			(fields.MethodId, "PaymentMethod")
		);
		
		DomainValidator<Bill>.ValidateNonNegativeNumbers(errors,
			(fields.Amount, nameof(fields.Amount)),
			(fields.SubTotal, nameof(fields.SubTotal)),
			(fields.Tax, nameof(fields.Tax)),
			(fields.Discount, nameof(fields.Discount))
		);
		
		return errors;
	}
}
