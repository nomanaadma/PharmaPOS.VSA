using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.PurchaseAggregate;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Infrastructure.Purchases.Persistence;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
	public void Configure(EntityTypeBuilder<Purchase> builder)
	{
		builder.ToTable("medicine_purchase");

		builder.HasKey(mp => mp.Id);

		builder.Property(mp => mp.Id)
			.HasColumnName("id");

		builder.Property(mp => mp.SupplierId)
			.HasColumnName("supplier")
			.IsRequired();

		builder.Property(mp => mp.Date)
			.HasColumnName("date")
			.HasColumnType("date")
			.IsRequired();

		builder.Property(mp => mp.SubTotal)
			.HasColumnName("sub_total")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mp => mp.Tax)
			.HasColumnName("tax")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mp => mp.Discount)
			.HasColumnName("discount_value")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mp => mp.Amount)
			.HasColumnName("amount")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mp => mp.Note)
			.HasColumnName("note")
			.HasColumnType("text");

		builder.Property(mp => mp.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();

		builder.HasOne<Supplier>()
			.WithMany()
			.HasForeignKey(mp => mp.SupplierId)
			.OnDelete(DeleteBehavior.Cascade);
		
	}
}
