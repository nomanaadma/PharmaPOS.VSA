using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.CustomerAggregate;
using PharmaPOS.Domain.PaymentMethodAggregate;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Infrastructure.Bills.Persistence;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
	public void Configure(EntityTypeBuilder<Bill> builder)
	{
		builder.ToTable("medicine_bill");

		builder.HasKey(mb => mb.Id);

		builder.Property(mb => mb.Id)
			.HasColumnName("id");

		builder.Property(mb => mb.CustomerId)
			.HasColumnName("customer_id")
			.IsRequired();

		builder.Property(mb => mb.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(mb => mb.Email)
			.HasColumnName("email")
			.HasMaxLength(254);

		builder.Property(mb => mb.Mobile)
			.HasColumnName("mobile")
			.HasMaxLength(30);

		builder.Property(mb => mb.MethodId)
			.HasColumnName("method")
			.IsRequired();

		builder.Property(mb => mb.Date)
			.HasColumnName("bill_date")
			.HasColumnType("date")
			.IsRequired();

		builder.Property(mb => mb.SubTotal)
			.HasColumnName("subtotal")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mb => mb.Tax)
			.HasColumnName("tax")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mb => mb.Discount)
			.HasColumnName("discount_value")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mb => mb.Amount)
			.HasColumnName("amount")
			.HasColumnType("decimal(10, 2)")
			.IsRequired();

		builder.Property(mb => mb.Note)
			.HasColumnName("note")
			.HasColumnType("text");

		builder.Property(mb => mb.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();

		builder.HasOne<Customer>()
			.WithMany()
			.HasForeignKey(mb => mb.CustomerId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne<PaymentMethod>()
			.WithMany()
			.HasForeignKey(mb => mb.MethodId)
			.OnDelete(DeleteBehavior.Cascade);

	}
}
