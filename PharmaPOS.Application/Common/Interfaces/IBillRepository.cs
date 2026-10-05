using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IBillRepository : IRepository<Bill>
{
	Task<DataTableResponse<BillingListResponse>> GetFilteredBillsAsync(
		DataTableRequest request, 
		DataTableColumnMap<BillingListResponse> columns, 
		CancellationToken ct = default);

	Task<Bill?> GetBillWithItemsAsync(int id, CancellationToken ct = default);
	Task<List<Bill>> GetRecentBillsAsync(int customerId, string? email, CancellationToken ct = default);
	Task<List<BillItem>> GetBillItemsForBatchesAsync(List<int> batchIds, CancellationToken ct = default);
	Task<bool> HasBillsByCustomerAsync(int customerId, CancellationToken ct = default);
}
