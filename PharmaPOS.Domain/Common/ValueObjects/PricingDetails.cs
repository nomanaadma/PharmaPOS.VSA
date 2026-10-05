using ErrorOr;
using PharmaPOS.Domain.Common.Errors;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Domain.Common.ValueObjects;

public record PricingDetails
{
	// EF Core parameterless constructor
	private PricingDetails() { }

	private PricingDetails(PricingFields pricingFields)
	{
		Qty = pricingFields.Qty;
		SalePrice = pricingFields.SalePrice;
		Gross = pricingFields.Gross;
		DiscountType = pricingFields.DiscountType;
		Discount = pricingFields.Discount;
		DiscountValue = pricingFields.DiscountValue;
		Tax = pricingFields.Tax;
		TaxPrice = pricingFields.TaxPrice;
		Price = pricingFields.Price;
	}

	public static ErrorOr<PricingDetails> Create(PricingFields pricingFields)
	{
		if (pricingFields.Qty < 0)
			return PricingErrors.NegativeQuantity;
		if (pricingFields.SalePrice < 0)
			return PricingErrors.NegativeSalePrice;

		return new PricingDetails(pricingFields);
	}



	public decimal Qty { get; private set; }
	public decimal SalePrice { get; private set; }
	public decimal Gross { get; private set; }
	public DiscountType DiscountType { get; private set; }
	public decimal Discount { get; private set; }
	public decimal DiscountValue { get; private set; }
	public decimal Tax { get; private set; }
	public decimal TaxPrice { get; private set; }
	public decimal Price { get; private set; }
}
