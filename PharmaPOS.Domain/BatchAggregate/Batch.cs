using ErrorOr;
using PharmaPOS.Domain.Common;
using PharmaPOS.Domain.Common.ValueObjects;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.BatchAggregate;

public class Batch : AggregateRoot
{
	// EF Core parameterless constructor
	private Batch() { }

	private Batch(BatchFields fields)
	{
		SetDetails(fields);
	}

	public string BatchName { get; private set; } = null!;
	public string Expiry { get; private set; } = null!;
	public string? Pqty { get; private set; }
	public PricingDetails Pricing { get; private set; } = null!;
	public decimal PurchasePrice { get; private set; }
	public decimal Sold { get; private set; }
	public int MedicineId { get; private set; }
	public int PurchaseId { get; private set; }
	public Status Status { get; private set; } = Status.Active;
	public DateTime CreatedDate { get; private init; }


	public static ErrorOr<Batch> Create(BatchFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Batch(fields);
	}

	public ErrorOr<Updated> Update(BatchFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		SetDetails(fields);
		return Result.Updated;
	}

	public ErrorOr<Success> UpdateSold(decimal quantity)
	{
		if (Sold + quantity > Pricing.Qty) 
			return BatchErrors.InsufficientStock;
			
		Sold += quantity;
		return Result.Success;
	}

	public void UpdateStatus(Status status)
	{
		Status = status;
	}

	private void SetDetails(BatchFields fields)
	{
		BatchName = fields.BatchName;
		Expiry = fields.Expiry;
		Pqty = fields.Pqty;
		Pricing = fields.Pricing;
		PurchasePrice = fields.PurchasePrice;
		MedicineId = fields.MedicineId;
		PurchaseId = fields.PurchaseId;
	}

	private static List<Error> ValidateFields(BatchFields fields)
	{
		var errors = new List<Error>();
		
		DomainValidator<Batch>.ValidateRequiredStrings(errors,
			(fields.BatchName, nameof(fields.BatchName)),
			(fields.Expiry, nameof(fields.Expiry))
		);

		DomainValidator<Batch>.ValidateIds(errors,
			(fields.MedicineId, nameof(fields.MedicineId)),
			(fields.PurchaseId, nameof(fields.PurchaseId))
		);

		DomainValidator<Batch>.ValidateNonNegativeNumbers(errors,
			(fields.PurchasePrice, nameof(fields.PurchasePrice))
		);
		
		
		return errors;
	}
}
