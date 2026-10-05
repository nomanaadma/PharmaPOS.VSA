using ErrorOr;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.Common;
using PharmaPOS.Domain.Common.ValueObjects;
using PharmaPOS.Domain.MedicineAggregate;
using PharmaPOS.Domain.PurchaseAggregate;

namespace PharmaPOS.Domain.BillingAggregate;

public class BillItem : Entity
{
	// EF Core parameterless constructor
	private BillItem() { }

	private BillItem(BillItemFields fields)
	{
		MedicineId = fields.MedicineId;
		BatchId = fields.BatchId;
		Pricing = fields.Pricing;
	}

	public int BillId { get; private set; }
	public int MedicineId { get; private set; }
	public int BatchId { get; private set; }
	public PricingDetails Pricing { get; private set; } = null!;
	
	/// <summary>
	/// Factory method: validates inputs and returns an ErrorOr&lt;Bill&gt;.
	/// </summary>
	public static ErrorOr<BillItem> Create(BillItemFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new BillItem(fields);
	}
	
	private static List<Error> ValidateFields(BillItemFields fields)
	{
		var errors = new List<Error>();
		
		if (fields.MedicineId <= 0)
			errors.Add(BillErrors.InvalidMedicine);
		
		if (fields.BatchId <= 0)
			errors.Add(BillErrors.InvalidBatch);
		
		return errors;
	}
}
