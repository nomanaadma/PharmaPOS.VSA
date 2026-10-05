namespace PharmaPOS.Razor.Models;

public abstract class ItemViewModel
{
	public string Name { get; init; } = string.Empty;
	public string Batch { get; init; } = string.Empty;
	public string Expiry { get; init; } = string.Empty;
	public decimal Qty { get; init; }
	public decimal SalePrice { get; init; }
	public decimal Gross { get; init; }
	public decimal DiscountValue { get; init; }
	public decimal TaxPrice { get; init; }
	public decimal Price { get; init; }
}