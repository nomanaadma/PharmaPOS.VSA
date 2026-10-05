using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PurchaseAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IPurchaseRepository : IRepository<Purchase>
{
	Task<DataTableResponse<PurchaseListResponse>> GetFilteredPurchasesAsync(
		DataTableRequest request, 
		DataTableColumnMap<PurchaseListResponse> columns, 
		CancellationToken ct = default);

	Task<bool> HasPurchasesBySupplierAsync(int supplierId, CancellationToken ct = default);
}
