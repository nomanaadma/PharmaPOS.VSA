using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IReportRepository
{
	Task<List<InventoryReportResponse>> GetInventoryReportAsync(CancellationToken ct = default);
	Task<StatsReportResponse> GetIncomeExpenseReportAsync(
		InventoryReportRequest request,
		CancellationToken ct = default);
}
