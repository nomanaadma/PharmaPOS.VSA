using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Razor.Models;

public class RoleListViewModel
{
    public string Id { get; init; } = null!;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string CreatedDate { get; init; } = string.Empty;
}

public class RoleFormViewModel
{
    public string? Id { get; init; }

    [Required(ErrorMessage = "User Role Name is required.")]
    [Display(Name = "User Role Name")]
    public string Name { get; init; } = string.Empty;

    [Display(Name = "Description")]
    public string? Description { get; init; }

    public List<string> SelectedPermissions { get; init; } = [];

    public Dictionary<string, Dictionary<string, string>> PermissionsGroup { get; set; } = [];
}
