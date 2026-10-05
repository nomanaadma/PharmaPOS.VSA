using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Contracts.Responses;

public record PricingDto
{
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