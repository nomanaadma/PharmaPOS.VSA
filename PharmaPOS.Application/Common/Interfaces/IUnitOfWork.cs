namespace PharmaPOS.Application.Common.Interfaces;

public interface IUnitOfWork
{
	IRepository<T> Repository<T>() where T : class;
	Task<int> SaveChangesAsync(CancellationToken ct = default);
	Task<IDbTransactionProxy> BeginTransactionAsync(CancellationToken ct = default);
}

public interface IDbTransactionProxy : IAsyncDisposable
{
	Task CommitAsync(CancellationToken ct = default);
	Task RollbackAsync(CancellationToken ct = default);
}
