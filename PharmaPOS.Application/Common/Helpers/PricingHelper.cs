using ErrorOr;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Domain.Common;
using PharmaPOS.Domain.Common.ValueObjects;

namespace PharmaPOS.Application.Common.Helpers;

public static class PricingHelper
{
	public static ErrorOr<PricingDetails> CreatePricingDetails(PricingDetailRequest item)
	{
		var pricingFields = new PricingFields(
			item.Qty, 
			item.SalePrice, 
			item.Gross, 
			item.DiscountType, 
			item.Discount, 
			item.DiscountValue, 
			item.Tax, 
			item.TaxPrice, 
			item.Price);
		
		return PricingDetails.Create(pricingFields);
		
	}
}