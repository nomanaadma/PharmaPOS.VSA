using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Stock.Queries.ListStock;

public class ListStockQueryHandler(
	IBatchRepository batchRepo,
	IBillRepository billRepo,
	IMedicineRepository medicineRepo) : IRequestHandler<ListStockQuery, List<BatchResponse>>
{
	public async Task<List<BatchResponse>> Handle(ListStockQuery query, CancellationToken ct)
	{
		var batches = await batchRepo.GetActiveBatchesAsync(query.Type, ct);
		var batchIds = batches.Select(b => b.Id).ToList();
		
		var medicineIds = batches.Select(b => b.MedicineId).Distinct().ToList();
		var medicineNames = await medicineRepo.GetMedicineNamesByIdsAsync(medicineIds, ct);
		
		var billItems = await billRepo.GetBillItemsForBatchesAsync(batchIds, ct);	
		
		return batches.Select(b =>
		{
			var unitSalePrice = 0m;
			var totalSales = 0m;
			var profit = 0m;
			
			var unitPurchasePrice = Math.Round(b.Pricing.Price / b.Pricing.Qty, 2);
			var totalPurchase = Math.Round(unitPurchasePrice * b.Sold, 2);

			var batchBillItems = billItems.Where(bi => bi.BatchId == b.Id).Where(bi => bi.MedicineId == b.MedicineId).ToList();

			var medicineSalePrice = 0m;
			var medicineSaleQty = 0m;
			
			foreach (var billItem in batchBillItems)
			{
				medicineSalePrice += billItem.Pricing.Price;
				medicineSaleQty += billItem.Pricing.Qty;
			}

			if (medicineSalePrice != 0 && medicineSaleQty != 0)
			{
				unitSalePrice += Math.Round(medicineSalePrice / medicineSaleQty, 2);
				totalSales += Math.Round(unitSalePrice * b.Sold, 2);
				profit += Math.Round(totalSales - totalPurchase, 2);
			}
			
			return new BatchResponse(
				Id: b.Id,
				MedicineId: b.MedicineId,
				PurchaseId: b.PurchaseId,
				Name: medicineNames.GetValueOrDefault(b.MedicineId, ""),
				Batch: b.BatchName,
				Expiry: b.Expiry,
				PurchasePrice: unitPurchasePrice,
				SalePrice: unitSalePrice,
				TotalPurchase: totalPurchase,
				TotalSales: totalSales,
				Profit: profit,
				Qty: b.Pricing.Qty,
				Sold: b.Sold,
				Available: b.Pricing.Qty - b.Sold
			);
			
		}).ToList();
	}
}
