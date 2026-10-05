using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaPOS.Domain.MediaAggregate;

namespace PharmaPOS.Infrastructure.Medias.Persistence;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
	public void Configure(EntityTypeBuilder<Media> builder)
	{

		builder.ToTable("media");
		
		builder.HasKey(m => m.Id);
		
		builder.Property(m => m.Id)
			.HasColumnName("id");
		
		builder.Property(m => m.Filename)
			.HasColumnName("media")
			.HasMaxLength(255)
			.IsRequired();
		
		builder.Property(m => m.Ext)
			.HasColumnName("ext")
			.HasMaxLength(10)
			.IsRequired();
		
		builder.Property(m => m.CreatedDate)
			.HasColumnName("created_date")
			.HasDefaultValueSql("CURRENT_TIMESTAMP")
			.IsRequired();
		
	}

}
