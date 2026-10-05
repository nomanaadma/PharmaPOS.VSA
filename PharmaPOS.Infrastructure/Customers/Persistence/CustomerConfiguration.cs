using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.CustomerAggregate;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.Customers.Persistence;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.ToTable("customers");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.HasColumnName("id");

		builder.Property(c => c.FirstName)
			.HasColumnName("firstname")
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.LastName)
			.HasColumnName("lastname")
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.Email)
			.HasColumnName("email")
			.IsRequired()
			.HasMaxLength(254);

		builder.HasIndex(c => c.Email)
			.IsUnique();

		builder.Property(c => c.Mobile)
			.HasColumnName("mobile")
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(c => c.Gender)
			.HasColumnName("gender")
			.HasConversion(
				v => v.HasValue ? v.Value.ToString() : "",
				v => ParseGender(v))
			.HasMaxLength(20);

		builder.Property(c => c.Status)
			.HasColumnName("status")
			.HasColumnType("boolean")
			.HasConversion(
				v => v == Status.Active,
				v => v ? Status.Active : Status.InActive)
			.IsRequired();

		builder.Property(c => c.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();
	}

	private static Gender? ParseGender(string value)
	{
		if (string.IsNullOrWhiteSpace(value)) return null;
		return Enum.TryParse<Gender>(value, true, out var result) ? result : null;
	}
}
