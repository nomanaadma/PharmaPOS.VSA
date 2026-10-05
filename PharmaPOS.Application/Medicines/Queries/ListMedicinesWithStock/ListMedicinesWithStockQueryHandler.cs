using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Medicines.Queries.ListMedicinesWithStock;

public class ListMedicinesWithStockQueryHandler(
	IMedicineRepository medicineRepo,
	ICategoryRepository categoryRepo) : IRequestHandler<ListMedicinesWithStockQuery, List<MedicineResponse>>
{
	public async Task<List<MedicineResponse>> Handle(ListMedicinesWithStockQuery query, CancellationToken ct)
	{
		var medicinesWithStock = await medicineRepo.GetMedicinesWithStockAsync(ct); 
		
		var categoryIds = medicinesWithStock.Select(msr => msr.medicine.CategoryId).Distinct().ToList();
		var categoriesNames = await categoryRepo.GetCategoryNamesByIdsAsync(categoryIds, ct);

		var medicinesResponse = new List<MedicineResponse>();

		foreach (var (medicine, liveStock) in medicinesWithStock)
		{
			var categoryName = categoriesNames.GetValueOrDefault(medicine.CategoryId, "");
			var responseResponse = medicine.Adapt<MedicineResponse>() with
			{
				CategoryName = categoryName,
				LiveStock = liveStock
			};
			
			medicinesResponse.Add(responseResponse);
		}

		return medicinesResponse;
	}
}
