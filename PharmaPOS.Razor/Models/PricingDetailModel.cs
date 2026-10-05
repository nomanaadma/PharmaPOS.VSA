using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Razor.Models;

public class PricingDetailModel : Model
{
	public int MedicineId { get; init; }
	public string Name { get; init; } = null!;
	public string Expiry { get; init; } = null!;
	public decimal Qty { get; init; }
	public decimal SalePrice { get; init; }
	public decimal Gross { get; init; }
	public DiscountType DiscountType { get; init; }
	public decimal Discount { get; init; }
	public decimal DiscountValue { get; init; }
	public decimal Tax { get; init; }
	public decimal TaxPrice { get; init; }
	public decimal Price { get; init; }
}