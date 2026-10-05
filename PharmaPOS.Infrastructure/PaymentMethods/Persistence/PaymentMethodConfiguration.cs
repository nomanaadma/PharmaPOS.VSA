using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.PaymentMethodAggregate;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.PaymentMethods.Persistence;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
	public void Configure(EntityTypeBuilder<PaymentMethod> builder)
	{
		builder.ToTable("payment_method");

		builder.HasKey(pm => pm.Id);

		builder.Property(pm => pm.Id)
			.HasColumnName("id");

		builder.Property(pm => pm.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(pm => pm.Status)
			.HasColumnName("status")
			.HasColumnType("boolean")
			.HasConversion(
				v => v == Status.Active,
				v => v ? Status.Active : Status.InActive)
			.IsRequired();

		builder.Property(pm => pm.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();

		builder.HasIndex(pm => pm.Name)
			.IsUnique();
	}
}
