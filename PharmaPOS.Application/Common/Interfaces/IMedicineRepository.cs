using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.MedicineAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IMedicineRepository : IRepository<Medicine>
{
	Task<List<(Medicine medicine, decimal liveStock)>> GetMedicinesWithStockAsync(CancellationToken ct = default);
	Task<Dictionary<int, string>> GetMedicineNamesByIdsAsync(List<int> medicineIds, CancellationToken ct = default);
	Task<List<MedicineSearchResult>> SearchMedicinesAsync(string term, int take = 10, CancellationToken ct = default);
}
