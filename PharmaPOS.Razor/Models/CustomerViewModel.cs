using System.ComponentModel.DataAnnotations;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Razor.Models;

public class CustomerViewModel : Model
{

	[Required(ErrorMessage = "First Name is required.")]
	[StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
	public string FirstName { get; init; } = null!;

	[Required(ErrorMessage = "Last Name is required.")]
	[StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
	public string LastName { get; init; } = null!;

	[Required(ErrorMessage = "Email Address is required.")]
	[EmailAddress(ErrorMessage = "Invalid Email Address.")]
	[StringLength(254, ErrorMessage = "Email Address cannot exceed 254 characters.")]
	public string Email { get; init; } = null!;

	[Required(ErrorMessage = "Mobile Number is required.")]
	[StringLength(30, ErrorMessage = "Mobile Number cannot exceed 30 characters.")]
	public string Mobile { get; init; } = null!;

	[Required(ErrorMessage = "Gender is required.")]
	[EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender value.")]
	public Gender? Gender { get; init; }

	[Required(ErrorMessage = "Status is required.")]
	[EnumDataType(typeof(Status), ErrorMessage = "Invalid status value.")]
	public Status Status { get; init; } = Status.Active;

	public DateTime? CreatedDate { get; init; }
}