namespace PharmaPOS.Domain.Common;

public abstract class OrderDetails : AggregateRoot
{
	public DateTime Date { get; protected set; }
	public decimal SubTotal { get; protected set; }
	public decimal Tax { get; protected set; }
	public decimal Discount { get; protected set; }
	public decimal Amount { get; protected set; }
	
	// ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
	public string? Note { get; protected set; }
	
	public DateTime CreatedDate { get; protected init;  }

}