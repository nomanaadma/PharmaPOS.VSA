using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.SettingAggregate;

public class Setting : AggregateRoot
{
	// EF Core parameterless constructor
	private Setting() { }

	private Setting(SettingFields fields)
	{
		SetDetails(fields);
		Address = Address.Empty;
	}

	public static ErrorOr<Setting> Create(SettingFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;

		return new Setting(fields);
	}

	public string? Logo { get; private set; }
	public string? LogoIcon { get; private set; }
	public string? LgBackground { get; private set; }
	public string? Favicon { get; private set; }
	public string Name { get; private set; } = null!;
	public string LegalName { get; private set; } = null!;
	public string Mail { get; private set; } = null!;
	public string Phone { get; private set; } = null!;
	public Address Address { get; private set; } = null!;

	public ErrorOr<Updated> Update(SettingFields fields)
	{
		var errors = ValidateFields(fields);
		if (errors.Count > 0) return errors;
		
		SetDetails(fields);
		return Result.Updated;
	}
	
	private static List<Error> ValidateFields(SettingFields fields)
	{
		var errors = new List<Error>();
		
		// Standard DomainValidator approach
		DomainValidator<Setting>.ValidateRequiredStrings(errors,
			(fields.Name, nameof(fields.Name)),
			(fields.LegalName, nameof(fields.LegalName)),
			(fields.Mail, nameof(fields.Mail)),
			(fields.Phone, nameof(fields.Phone))
		);
		
		return errors;
	}
	
	private void SetDetails(SettingFields fields)
	{
		Name = fields.Name;
		LegalName = fields.LegalName;
		Mail = fields.Mail;
		Phone = fields.Phone;
	}

	public void UpdateImages(string? logo, string? logoIcon, string? lgBackground, string? favicon)
	{
		Logo = logo;
		LogoIcon = logoIcon;
		LgBackground = lgBackground;
		Favicon = favicon;
	}

	public void UpdateAddress(Address address)
	{
		Address = address;
	}
}
