using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Infrastructure.Common.Persistence;

public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
	public void Configure(EntityTypeBuilder<OutboxMessage> builder)
	{
		builder.ToTable("OutboxMessages");

		builder.HasKey(x => x.Id);

		builder.Property(x => x.Type)
			.IsRequired()
			.HasMaxLength(500);

		builder.Property(x => x.Content)
			.IsRequired();

		builder.Property(x => x.OccurredOn)
			.IsRequired();

		builder.Property(x => x.RetryCount)
			.HasDefaultValue(0);

		// Index for the background processor query:
		// WHERE ProcessedOn IS NULL AND RetryCount < maxRetries
		builder.HasIndex(x => new { x.ProcessedOn, x.RetryCount })
			.HasFilter("\"ProcessedOn\" IS NULL")
			.HasDatabaseName("IX_OutboxMessages_Unprocessed");
	}
}
