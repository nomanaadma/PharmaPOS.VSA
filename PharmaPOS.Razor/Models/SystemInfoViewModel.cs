using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Razor.Models;

public class SystemInfoViewModel
{
	public string? Logo { get; init; }
	public string? LogoIcon { get; init; }
	public string? LgBackground { get; init; }
	public string? Favicon { get; init; }

	[Required(ErrorMessage = "Store Name is required.")]
	public string Name { get; init; } = null!;

	[Required(ErrorMessage = "Store Legal Name is required.")]
	public string LegalName { get; init; } = null!;

	[Required(ErrorMessage = "Email Address is required.")]
	[EmailAddress(ErrorMessage = "Invalid Email Address.")]
	public string Mail { get; init; } = null!;

	[Required(ErrorMessage = "Phone Number is required.")]
	public string Phone { get; init; } = null!;

	public string? AddressLine1 { get; init; }
	public string? AddressLine2 { get; init; }
	public string? City { get; init; }
	public string? Country { get; init; }
	public string? Postal { get; init; }
}
