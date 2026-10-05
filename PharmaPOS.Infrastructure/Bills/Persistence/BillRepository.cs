using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BillingAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Bills.Persistence;

public class BillRepository(ApplicationDbContext context) : Repository<Bill>(context), IBillRepository
{
	public async Task<DataTableResponse<BillingListResponse>> GetFilteredBillsAsync(
		DataTableRequest request, 
		DataTableColumnMap<BillingListResponse> columns, 
		CancellationToken ct = default)
	{
		var query = DbSet.Select(b => new BillingListResponse {
			Id = b.Id,
			Date = b.Date,
			SubTotal = b.SubTotal,
			Tax = b.Tax,
			Discount = b.Discount,
			Amount = b.Amount,
			Note = b.Note,
			Name = b.Name
		}).AsQueryable();
		
		return await query.ToDataTableAsync(request, columns, ct);
	}

	public async Task<Bill?> GetBillWithItemsAsync(int id, CancellationToken ct = default)
	{
		return await DbSet
			.Include(b => b.Items)
			.FirstOrDefaultAsync(b => b.Id == id, ct);
	}
	
	public async Task<List<Bill>> GetRecentBillsAsync(int customerId, string? email, CancellationToken ct = default)
	{
		return await DbSet
			.Where(b => b.CustomerId == customerId || (email != null && b.Email == email))
			.OrderByDescending(b => b.Date)
			.Take(20)
			.ToListAsync(ct);
	}

	public async Task<List<BillItem>> GetBillItemsForBatchesAsync(List<int> batchIds, CancellationToken ct = default)
	{
		return await DbContext.BillItems
			.Where(bi => batchIds.Contains(bi.BatchId))
			.ToListAsync(ct);
	}

	public async Task<bool> HasBillsByCustomerAsync(int customerId, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(b => b.CustomerId == customerId, ct);
	}
}
