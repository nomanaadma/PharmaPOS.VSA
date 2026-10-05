using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure.Common.BackgroundJobs;

public class OutboxMessageProcessor(
	IServiceScopeFactory scopeFactory,
	ILogger<OutboxMessageProcessor> logger) : BackgroundService
{
	private const int BatchSize = 20;
	private const int MaxRetries = 3;
	private static readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(5);
	private static readonly TimeSpan CleanupInterval = TimeSpan.FromHours(1);
	private DateTime _lastCleanup = DateTime.MinValue;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		logger.LogInformation("Outbox Message Processor started.");

		while (!stoppingToken.IsCancellationRequested)
		{
			try
			{
				await ProcessOutboxMessagesAsync(stoppingToken);
				await CleanupOldMessagesAsync(stoppingToken);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Error occurred while processing outbox messages.");
			}

			await Task.Delay(PollingInterval, stoppingToken);
		}
		
		logger.LogInformation("Outbox Message Processor stopped.");
	}

	private async Task ProcessOutboxMessagesAsync(CancellationToken ct)
	{
		using var scope = scopeFactory.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
		var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

		var messages = await dbContext.OutboxMessages
			.Where(m => m.ProcessedOn == null && m.RetryCount < MaxRetries)
			.OrderBy(m => m.OccurredOn)
			.Take(BatchSize)
			.ToListAsync(ct);

		if (messages.Count == 0) return;

		foreach (var message in messages)
		{
			try
			{
				var eventType = Type.GetType(message.Type);

				if (eventType is null)
				{
					logger.LogWarning(
						"Could not resolve type '{Type}' for outbox message {Id}. Skipping.",
						message.Type, message.Id);
					message.Error = $"Could not resolve type: {message.Type}";
					message.RetryCount = MaxRetries; // Don't retry unresolvable types
					continue;
				}

				var domainEvent = JsonSerializer.Deserialize(message.Content, eventType);

				if (domainEvent is null)
				{
					logger.LogWarning(
						"Failed to deserialize outbox message {Id} of type '{Type}'. Skipping.",
						message.Id, message.Type);
					message.Error = "Deserialization returned null";
					message.RetryCount = MaxRetries;
					continue;
				}

				await publisher.Publish(domainEvent, ct);

				message.ProcessedOn = DateTime.UtcNow;
				message.Error = null;

				logger.LogDebug(
					"Successfully processed outbox message {Id} of type '{Type}'.",
					message.Id, message.Type);
			}
			catch (Exception ex)
			{
				message.RetryCount++;
				message.Error = ex.Message;

				logger.LogWarning(ex,
					"Failed to process outbox message {Id} (attempt {Attempt}/{Max}).",
					message.Id, message.RetryCount, MaxRetries);
			}
		}

		await dbContext.SaveChangesAsync(ct);
	}

	private async Task CleanupOldMessagesAsync(CancellationToken ct)
	{
		if (DateTime.UtcNow - _lastCleanup < CleanupInterval) return;

		using var scope = scopeFactory.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		var cutoff = DateTime.UtcNow.AddDays(-7);
		
		var deletedCount = await dbContext.OutboxMessages
			.Where(m => m.ProcessedOn != null && m.ProcessedOn < cutoff)
			.ExecuteDeleteAsync(ct);

		if (deletedCount > 0)
		{
			logger.LogInformation("Cleaned up {Count} old outbox messages.", deletedCount);
		}

		_lastCleanup = DateTime.UtcNow;
	}
}
