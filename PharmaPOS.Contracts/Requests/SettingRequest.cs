namespace PharmaPOS.Contracts.Requests;

public record SettingRequest(string? Logo,
	string? LogoIcon,
	string? LgBackground,
	string? Favicon,
	string Name,
	string LegalName,
	string Mail,
	string Phone,
	string? AddressLine1,
	string? AddressLine2,
	string? City,
	string? Country,
	string? Postal
);