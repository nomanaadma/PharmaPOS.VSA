using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PurchaseAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Purchases.Persistence;

public class PurchaseRepository(
	ApplicationDbContext context
	) : Repository<Purchase>(context), IPurchaseRepository
{
	public async Task<DataTableResponse<PurchaseListResponse>> GetFilteredPurchasesAsync(
		DataTableRequest request, 
		DataTableColumnMap<PurchaseListResponse> columns, 
		CancellationToken ct = default)
	{
		var query = DbSet
			.AsNoTracking()
			.Join(DbContext.Suppliers, p => p.SupplierId, s => s.Id, (p, s) => new PurchaseListResponse
			{
				Id = p.Id,
				Date = p.Date,
				SubTotal = p.SubTotal,
				Tax = p.Tax,
				Discount = p.Discount,
				Amount = p.Amount,
				Note = p.Note,
				SupplierName = s.Name
			});

		return await query.ToDataTableAsync(request, columns, ct);
	}

	public async Task<bool> HasPurchasesBySupplierAsync(int supplierId, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(p => p.SupplierId == supplierId, ct);
	}
}
