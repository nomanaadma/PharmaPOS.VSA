using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.MedicineAggregate;
using PharmaPOS.Domain.PurchaseAggregate;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Infrastructure.Batches.Persistence;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
	public void Configure(EntityTypeBuilder<Batch> builder)
	{
		builder.ToTable("medicine_batch");

		builder.HasKey(mb => mb.Id);

		builder.Property(mb => mb.Id)
			.HasColumnName("id");

		builder.Property(mb => mb.BatchName)
			.HasColumnName("batch")
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(mb => mb.Expiry)
			.HasColumnName("expiry")
			.IsRequired()
			.HasMaxLength(10);

		builder.Property(mb => mb.Pqty)
			.HasColumnName("pqty")
			.HasMaxLength(10);

		builder.OwnsOne(mb => mb.Pricing, p =>
		{
			p.Property(x => x.Qty)
				.HasColumnName("qty")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.SalePrice)
				.HasColumnName("saleprice")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.Gross)
				.HasColumnName("gross")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.DiscountType)
				.HasColumnName("discounttype")
				.IsRequired();

			p.Property(x => x.Discount)
				.HasColumnName("discount")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.DiscountValue)
				.HasColumnName("discountvalue")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.Tax)
				.HasColumnName("tax")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.TaxPrice)
				.HasColumnName("taxprice")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();

			p.Property(x => x.Price)
				.HasColumnName("price")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();
		});

		builder.Property(mb => mb.PurchasePrice)
			.HasColumnName("purchaseprice")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mb => mb.Sold)
			.HasColumnName("sold")
			.HasColumnType("decimal(10, 2)")
			.HasDefaultValue(0.00)
			.IsRequired();

		builder.Property(mb => mb.MedicineId)
			.HasColumnName("medicine_id")
			.IsRequired();

		builder.Property(mb => mb.PurchaseId)
			.HasColumnName("purchase_id")
			.IsRequired();

		builder.Property(mb => mb.Status)
			.HasColumnName("status")
			.HasColumnType("boolean")
			.HasConversion(
				v => v == Status.Active,
				v => v ? Status.Active : Status.InActive)
			.IsRequired();

		builder.Property(mb => mb.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();

		builder.HasOne<Medicine>()
			.WithMany()
			.HasForeignKey(mb => mb.MedicineId)
			.OnDelete(DeleteBehavior.Cascade);
		
		builder.HasOne<Purchase>()
			.WithMany()
			.HasForeignKey(mb => mb.PurchaseId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
