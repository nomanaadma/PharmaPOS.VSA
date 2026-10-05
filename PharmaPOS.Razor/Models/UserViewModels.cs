using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Razor.Models;

public class UserListViewModel
{
    public string Id { get; init; } = null!;
    public string FullName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Mobile { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    
    public Status Status { get; init; }
    public string CreatedDate { get; init; } = string.Empty;
}

public class UserFormViewModel
{
    public string? UserId { get; init; }

    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name = "First Name")]
    public string FirstName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name = "Last Name")]
    public string LastName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Mobile Number is required.")]
    [Phone(ErrorMessage = "Please enter a valid mobile number.")]
    [Display(Name = "Mobile Number")]
    public string Mobile { get; init; } = string.Empty;

    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email Address")]
    public string Email { get; init; } = string.Empty;

    [Display(Name = "Gender")]
    public Gender Gender { get; init; }

    [Display(Name = "Status")]
    public Status Status { get; init; }

    [Required(ErrorMessage = "User Role is required.")]
    [Display(Name = "User Role")]
    public string UserRole { get; init; } = string.Empty;

    [Required(ErrorMessage = "User Name is required.")]
    [Display(Name = "User Name")]
    public string UserName { get; init; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; init; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; init; }

    public DateTime CreatedDate { get; init; } = DateTime.Now;

    public IEnumerable<SelectListItem> Roles { get; set; } = [];
}
