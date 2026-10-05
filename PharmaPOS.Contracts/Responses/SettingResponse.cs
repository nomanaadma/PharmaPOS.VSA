namespace PharmaPOS.Contracts.Responses;

public record SettingResponse(
	int Id,
	string? Logo,
	string? LogoIcon,
	string? LgBackground,
	string? Favicon,
	string Name,
	string LegalName,
	string Mail,
	string Phone,
	AddressResponse Address
);

public record AddressResponse(
	string Line1,
	string? Line2,
	string? City,
	string? Country,
	string? Postal
){
	public override string ToString()
	{
		var parts = new[] { Line1, Line2, City, Country, Postal }
			.Where(p => !string.IsNullOrWhiteSpace(p));
            
		return string.Join(", ", parts);
	}
}