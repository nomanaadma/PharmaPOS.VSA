using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PaymentMethodAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.PaymentMethods.Persistence;

public class PaymentMethodRepository(ApplicationDbContext context) : Repository<PaymentMethod>(context), IPaymentMethodRepository
{
	public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(p => p.Name == name && (!excludeId.HasValue || p.Id != excludeId.Value), ct);
	}

	public async Task<List<LookupItem>> GetActiveLookupListAsync(CancellationToken ct = default)
	{
		return await DbSet
			.Where(pm => pm.Status == Status.Active)
			.Select(pm => new LookupItem(pm.Id.ToString(), pm.Name))
			.ToListAsync(ct);
	}

	public async Task<string> GetMethodNameByIdAsync(int id, CancellationToken ct = default )
	{
		return await DbSet
			.Where(pm => pm.Id == id)
			.Select(pm => pm.Name)
			.FirstOrDefaultAsync(ct) ?? "Unknown";
	}
	
}
