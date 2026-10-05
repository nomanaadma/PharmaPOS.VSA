using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.BillingAggregate;
using PharmaPOS.Domain.MedicineAggregate;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Infrastructure.Bills.Persistence;

public class BillItemConfiguration : IEntityTypeConfiguration<BillItem>
{
	public void Configure(EntityTypeBuilder<BillItem> builder)
	{
		builder.ToTable("bill_items");

		builder.HasKey(bi => bi.Id);

		builder.Property(bi => bi.Id)
			.HasColumnName("id");

		builder.Property(bi => bi.BillId)
			.HasColumnName("bill_id")
			.IsRequired();

		builder.Property(bi => bi.MedicineId)
			.HasColumnName("medicine_id")
			.IsRequired();

		builder.Property(bi => bi.BatchId)
			.HasColumnName("batch")
			.IsRequired();

		builder.OwnsOne(bi => bi.Pricing, p =>
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
		
		builder.HasOne<Bill>()
			.WithMany(b => b.Items)
			.HasForeignKey(bi => bi.BillId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne<Medicine>()
			.WithMany()
			.HasForeignKey(bi => bi.MedicineId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne<Batch>()
			.WithMany()
			.HasForeignKey(bi => bi.BatchId)
			.OnDelete(DeleteBehavior.Cascade);
		
	}
}
