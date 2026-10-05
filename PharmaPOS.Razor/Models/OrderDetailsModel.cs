using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Razor.Models;

public class OrderDetailsModel<T> : Model
{
	
	[Required(ErrorMessage = "Date is required.")]
	[DataType(DataType.Date)]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime Date { get; init; } = DateTime.Now;

	public string? Note { get; init; }
	public decimal SubTotal { get; init; }
	public decimal Tax { get; init; }
	public decimal Discount { get; init; }
	public decimal Amount { get; init; }
	public List<T> Items { get; init; } = [];
}