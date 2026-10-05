using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Razor.Models;

public class SupplierViewModel : Model
{

	[Required(ErrorMessage = "Supplier Name is required.")]
	[StringLength(150, ErrorMessage = "Supplier Name cannot exceed 150 characters.")]
	public string Name { get; init; } = null!;

	[Required(ErrorMessage = "Email Address is required.")]
	[EmailAddress(ErrorMessage = "Invalid Email Address.")]
	[StringLength(254, ErrorMessage = "Email Address cannot exceed 254 characters.")]
	public string Email { get; init; } = null!;

	[Required(ErrorMessage = "Phone Number is required.")]
	[StringLength(30, ErrorMessage = "Phone Number cannot exceed 30 characters.")]
	public string Phone { get; init; } = null!;

	[StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
	public string? Address { get; init; }
}
