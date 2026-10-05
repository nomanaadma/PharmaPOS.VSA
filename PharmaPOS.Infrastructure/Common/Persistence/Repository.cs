using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Interfaces;

namespace PharmaPOS.Infrastructure.Common.Persistence;

public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
{
	protected readonly ApplicationDbContext DbContext = context;
	protected readonly DbSet<T> DbSet = context.Set<T>();

	public virtual async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
	{
		return await DbSet.FindAsync([id], ct);
	}

	public virtual async Task<List<T>> GetAllAsync(CancellationToken ct = default)
	{
		return await DbSet.ToListAsync(ct);
	}

	public virtual async Task<T> AddAsync(T entity, CancellationToken ct = default)
	{
		await DbSet.AddAsync(entity, ct);
		return entity;
	}

	public virtual void Update(T entity)
	{
		DbSet.Update(entity);
	}

	public virtual void Remove(T entity)
	{
		DbSet.Remove(entity);
	}
}
