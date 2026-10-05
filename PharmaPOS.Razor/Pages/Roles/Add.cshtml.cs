using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using UserRole = PharmaPOS.Application.Common.Authorization.Roles;

using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Roles;

[Authorize(Roles = UserRole.Admin)]
public class AddModel(RoleManager<IdentityRole> roleManager) : BasePageModel
{
    [BindProperty]
    public RoleFormViewModel Input { get; set; } = new();

    public IActionResult OnGet()
    {
        Input.PermissionsGroup = Permissions.GetPermissionsTemplate();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Input.PermissionsGroup = Permissions.GetPermissionsTemplate();
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (await roleManager.RoleExistsAsync(Input.Name))
        {
            ModelState.AddModelError("Input.Name", $"Role '{Input.Name}' already exists.");
            return Page();
        }

        var role = new IdentityRole(Input.Name);
        var result = await roleManager.CreateAsync(role);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        // Add Description & CreatedDate claims
        if (!string.IsNullOrWhiteSpace(Input.Description))
        {
            await roleManager.AddClaimAsync(role, new Claim("Description", Input.Description));
        }
        await roleManager.AddClaimAsync(role, new Claim("CreatedDate", DateTime.UtcNow.ToString("o")));

        // Add Selected Permission claims
        if (Input.SelectedPermissions.Count > 0)
        {
            foreach (var permission in Input.SelectedPermissions)
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }

        NotifySuccess("User role created successfully.");
        return RedirectToPage("/Roles/Index");
    }
}
