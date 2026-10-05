using Mapster;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Common.Mappers;

public class BatchMapper : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Batch, BatchResponse>()
			.Map(dest => dest.Batch, src => src.BatchName)
			.Map(dest => dest.Qty, src => src.Pricing.Qty)
			.Map(dest => dest.SalePrice, src => src.Pricing.SalePrice)
			.Map(dest => dest.Available, src => src.Pricing.Qty - src.Sold)
			.Map(dest => dest.TotalPurchase, src => src.PurchasePrice * src.Pricing.Qty) 
			.Map(dest => dest.TotalSales, src => src.Pricing.SalePrice * src.Sold)
			.Map(dest => dest.Profit, src => (src.Pricing.SalePrice * src.Sold) - (src.PurchasePrice * src.Sold));

	}
}