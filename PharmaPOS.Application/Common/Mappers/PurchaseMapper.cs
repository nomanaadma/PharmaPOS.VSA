using Mapster;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Common.Mappers;

public class PurchaseMapper : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		
		config.NewConfig<Batch, PurchaseItemResponse>()
			.Map(dest => dest.Batch, src => src.BatchName)
			.Map(dest => dest.Purchaseprice, src => src.PurchasePrice)
			.Map(dest => dest.Qty, src => src.Pricing.Qty)
			.Map(dest => dest.SalePrice, src => src.Pricing.SalePrice)
			.Map(dest => dest.Gross, src => src.Pricing.Gross)
			.Map(dest => dest.DiscountType, src => src.Pricing.DiscountType)
			.Map(dest => dest.Discount, src => src.Pricing.Discount)
			.Map(dest => dest.DiscountValue, src => src.Pricing.DiscountValue)
			.Map(dest => dest.Tax, src => src.Pricing.Tax)
			.Map(dest => dest.TaxPrice, src => src.Pricing.TaxPrice)
			.Map(dest => dest.Price, src => src.Pricing.Price);
		
	}
}