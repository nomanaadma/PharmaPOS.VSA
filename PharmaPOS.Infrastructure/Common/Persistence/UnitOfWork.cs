using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.Common;
using MediatR;

namespace PharmaPOS.Infrastructure.Common.Persistence;

public class UnitOfWork(
	ApplicationDbContext context, 
	IPublisher publisher) : IUnitOfWork
{
	private readonly Dictionary<Type, object> _repositories = new();

	public IRepository<T> Repository<T>() where T : class
	{
		if (_repositories.TryGetValue(typeof(T), out var repo))
		{
			return (IRepository<T>)repo;
		}

		var newRepo = new Repository<T>(context);
		_repositories[typeof(T)] = newRepo;
		return newRepo;
	}

	public async Task<int> SaveChangesAsync(CancellationToken ct = default)
	{
		
		var domainEntities = context.ChangeTracker
			.Entries<AggregateRoot>()
			.Where(x => x.Entity.DomainEvents.Count != 0)
			.ToList();

		var domainEvents = domainEntities
			.SelectMany(x => x.Entity.DomainEvents)
			.ToList();

		domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

		// Publish synchronous events directly before saving
		foreach (var domainEvent in domainEvents.Where(e => e is not IAsyncDomainEvent))
		{
			await publisher.Publish(domainEvent, ct);
		}
		
		// Serialize async events into OutboxMessages (saved in the same transaction)
		var asyncEvents = domainEvents
			.Where(e => e is IAsyncDomainEvent)
			.ToList();
		
		foreach (var asyncEvent in asyncEvents)
		{
			var outboxMessage = new OutboxMessage
			{
				Id = Guid.NewGuid(),
				Type = asyncEvent.GetType().AssemblyQualifiedName!,
				Content = JsonSerializer.Serialize(asyncEvent, asyncEvent.GetType()),
				OccurredOn = DateTime.UtcNow,
			};
			
			context.OutboxMessages.Add(outboxMessage);
		}
		
		// Save changes to the database (business data + outbox messages in one transaction)
		return await context.SaveChangesAsync(ct);
		
	}

	public async Task<IDbTransactionProxy> BeginTransactionAsync(CancellationToken ct = default)
	{
		var transaction = await context.Database.BeginTransactionAsync(ct);
		return new DbTransactionProxy(transaction);
	}
	
}

public class DbTransactionProxy(IDbContextTransaction transaction) : IDbTransactionProxy
{
	public async Task CommitAsync(CancellationToken ct = default)
	{
		await transaction.CommitAsync(ct);
	}

	public async Task RollbackAsync(CancellationToken ct = default)
	{
		await transaction.RollbackAsync(ct);
	}

	public async ValueTask DisposeAsync()
	{
		await transaction.DisposeAsync();
		GC.SuppressFinalize(this);
	}
}
