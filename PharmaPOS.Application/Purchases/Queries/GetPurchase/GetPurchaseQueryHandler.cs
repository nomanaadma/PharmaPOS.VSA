using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PurchaseAggregate;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Application.Purchases.Queries.GetPurchase;

public class GetPurchaseQueryHandler(
	IPurchaseRepository purchaseRepo,
	IBatchRepository batchRepo,
	IMedicineRepository medicineRepo,
	ISupplierRepository supplierRepo) : IRequestHandler<GetPurchaseQuery, ErrorOr<PurchaseResponse>>
{
	public async Task<ErrorOr<PurchaseResponse>> Handle(GetPurchaseQuery query, CancellationToken ct)
	{
		var purchase = await purchaseRepo.GetByIdAsync(query.Id, ct);
		if (purchase == null)
			return CommonErrors<Purchase>.NotFound(query.Id);
		
		var supplier = await supplierRepo.GetByIdAsync(purchase.SupplierId, ct);
		if(supplier == null)
			return CommonErrors<Supplier>.NotFound(query.Id);
		
		var batches = await batchRepo.GetBatchesByPurchaseIdAsync(query.Id, ct);

		var purchaseItems = batches.Adapt<List<PurchaseItemResponse>>(); 

		var medicineIds = purchaseItems.Select(b => b.MedicineId).Distinct().ToList();

		var medicineNames = await medicineRepo.GetMedicineNamesByIdsAsync(medicineIds, ct);

		foreach (var purchaseItem in purchaseItems)
		{
			var name = medicineNames.GetValueOrDefault(purchaseItem.MedicineId, "");
			purchaseItem.Name = name;
		}

		var purchaseResponse = purchase.Adapt<PurchaseResponse>() with
		{
			Items = purchaseItems,
			SupplierName = supplier.Name,
			SupplierEmail = supplier.Email,
			SupplierPhone = supplier.Phone,
			Supplier = supplier.Id
		};

		return purchaseResponse;
	}
}

