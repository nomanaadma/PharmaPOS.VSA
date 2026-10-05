using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Infrastructure.Suppliers.Persistence;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
	public void Configure(EntityTypeBuilder<Supplier> builder)
	{
		builder.ToTable("suppliers");

		builder.HasKey(s => s.Id);

		builder.Property(s => s.Id)
			.HasColumnName("id");

		builder.Property(s => s.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(s => s.Email)
			.HasColumnName("email")
			.IsRequired()
			.HasMaxLength(254);

		builder.HasIndex(s => s.Email)
			.IsUnique();

		builder.Property(s => s.Phone)
			.HasColumnName("phone")
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(s => s.Address)
			.HasColumnName("address")
			.HasMaxLength(500);

		builder.Property(s => s.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();
	}
}
