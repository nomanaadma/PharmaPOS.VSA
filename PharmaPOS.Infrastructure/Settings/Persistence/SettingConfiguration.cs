using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PharmaPOS.Infrastructure.Settings.Persistence;

public class SettingConfiguration : IEntityTypeConfiguration<Domain.SettingAggregate.Setting>
{
	public void Configure(EntityTypeBuilder<Domain.SettingAggregate.Setting> builder)
	{

		builder.ToTable("settings");

		builder.HasKey(s => s.Id);

		builder.Property(s => s.Id)
			.HasColumnName("id");

		builder.Property(s => s.Logo)
			.HasColumnName("logo")
			.HasMaxLength(255);

		builder.Property(s => s.LogoIcon)
			.HasColumnName("logo_icon")
			.HasMaxLength(255);

		builder.Property(s => s.LgBackground)
			.HasColumnName("lg_background")
			.HasMaxLength(255);

		builder.Property(s => s.Favicon)
			.HasColumnName("favicon")
			.HasMaxLength(255);

		builder.Property(s => s.Name)
			.HasColumnName("name")
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(s => s.LegalName)
			.HasColumnName("legal_name")
			.IsRequired()
			.HasMaxLength(200);

		builder.Property(s => s.Mail)
			.HasColumnName("mail")
			.IsRequired()
			.HasMaxLength(254);

		builder.Property(s => s.Phone)
			.HasColumnName("phone")
			.IsRequired()
			.HasMaxLength(30);
		
		builder.ComplexProperty(s => s.Address, a =>
		{
			a.Property(p => p.Line1)
				.HasColumnName("address_line1")
				.HasMaxLength(200);

			a.Property(p => p.Line2)
				.HasColumnName("address_line2")
				.HasMaxLength(200);

			a.Property(p => p.City)
				.HasColumnName("city")
				.HasMaxLength(100);

			a.Property(p => p.Country)
				.HasColumnName("country")
				.HasMaxLength(100);

			a.Property(p => p.Postal)
				.HasColumnName("postal")
				.HasMaxLength(20);
		});
		
	}

}
