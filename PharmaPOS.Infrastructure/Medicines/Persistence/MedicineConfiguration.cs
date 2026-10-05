using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.CategoryAggregate;
using PharmaPOS.Domain.MedicineAggregate;

namespace PharmaPOS.Infrastructure.Medicines.Persistence;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
	public void Configure(EntityTypeBuilder<Medicine> builder)
	{
		builder.ToTable("medicines");

		builder.HasKey(m => m.Id);

		builder.Property(m => m.Id)
			.HasColumnName("id");

		builder.Property(m => m.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(m => m.Company)
			.HasColumnName("company")
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(m => m.Generic)
			.HasColumnName("generic")
			.IsRequired();

		builder.Property(m => m.MedicineGroup)
			.HasColumnName("medicine_group")
			.HasMaxLength(255);

		builder.Property(m => m.CategoryId)
			.HasColumnName("category")
			.IsRequired();

		builder.Property(m => m.StoreBox)
			.HasColumnName("storebox")
			.HasMaxLength(255);

		builder.Property(m => m.MinLevel)
			.HasColumnName("minlevel");

		builder.Property(m => m.ReOrderLevel)
			.HasColumnName("reorderlevel");

		builder.Property(m => m.Unit)
			.HasColumnName("unit")
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(m => m.UnitPacking)
			.HasColumnName("unitpacking")
			.HasMaxLength(255);

		builder.Property(m => m.Note)
			.HasColumnName("note");

		builder.Property(m => m.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();

		builder.HasOne<Category>()
			.WithMany()
			.HasForeignKey(m => m.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);
		
	}
}
