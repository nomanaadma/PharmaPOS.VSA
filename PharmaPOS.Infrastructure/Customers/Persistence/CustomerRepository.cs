using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.CustomerAggregate;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Customers.Persistence;

public class CustomerRepository(ApplicationDbContext context) : Repository<Customer>(context), ICustomerRepository
{
	public override async Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
	{
		return await DbSet
			.OrderByDescending(c => c.CreatedDate)
			.ToListAsync(ct);
	}

	public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null, CancellationToken ct = default)
	{
		return await DbSet.AnyAsync(c => c.Email == email && (!excludeId.HasValue || c.Id != excludeId.Value), ct);
	}

	public async Task<List<CustomerSearchResult>> SearchCustomersAsync(string term, int take = 7, CancellationToken ct = default)
	{
		return await DbSet
			.Where(c => EF.Functions.ILike(c.FirstName, $"%{term}%") ||
			            EF.Functions.ILike(c.LastName, $"%{term}%") ||
			            (c.Mobile != null && EF.Functions.ILike(c.Mobile, $"%{term}%")))
			.Take(take)
			.Select(c => new CustomerSearchResult(
				c.Id,
				c.FirstName + " " + c.LastName,
				c.Email,
				c.Mobile
			))
			.ToListAsync(ct);
	}

	public async Task<Customer?> FindByEmailOrPhoneAsync(string? email, string? phone, CancellationToken ct = default)
	{
		if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phone))
			return null;

		return await DbSet
			.FirstOrDefaultAsync(c => 
				(!string.IsNullOrWhiteSpace(email) && c.Email == email) || 
				(!string.IsNullOrWhiteSpace(phone) && c.Mobile == phone), ct);
	}
}
