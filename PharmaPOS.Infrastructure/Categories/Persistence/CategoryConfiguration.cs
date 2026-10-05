using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.CategoryAggregate;

namespace PharmaPOS.Infrastructure.Categories.Persistence;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("medicine_categories");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Id)
			.HasColumnName("id");

		builder.Property(c => c.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(100);

		builder.HasIndex(c => c.Name)
			.IsUnique();
	}
}
