using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Mappers;
using PharmaPOS.Razor.Models;
using UserRole = PharmaPOS.Application.Common.Authorization.Roles;

namespace PharmaPOS.Razor.Pages.Roles;

[Authorize(Roles = UserRole.Admin)]
public class EditModel(RoleManager<IdentityRole> roleManager) : BasePageModel
{
    [BindProperty]
    public RoleFormViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string id, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return RedirectToPage("/Roles/Index");
        }

        var role = await roleManager.FindByIdAsync(id);
        if (role == null)
        {
            NotifyWarning("Role does not exist in database!");
            return RedirectToPage("/Roles/Index");
        }

        if (role.Name == UserRole.Admin)
        {
            NotifyWarning("You can not change Admin role setting.");
            return RedirectToPage("/Roles/Index");
        }

        var claims = await roleManager.GetClaimsAsync(role);
        var description = claims.GetClaim("Description");
        var selectedPermissions = claims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();

        Input = RoleMapper.MapToRoleForm(role, description, selectedPermissions);
        Input.PermissionsGroup = Permissions.GetPermissionsTemplate();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id, CancellationToken ct)
    {
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        Input.PermissionsGroup = Permissions.GetPermissionsTemplate();

        if (string.IsNullOrWhiteSpace(Input.Id))
        {
            return RedirectToPage("/Roles/Index");
        }

        var role = await roleManager.FindByIdAsync(Input.Id);
        if (role == null)
        {
            NotifyWarning("Role does not exist in database!");
            return RedirectToPage("/Roles/Index");
        }

        if (role.Name == UserRole.Admin)
        {
            NotifyWarning("You can not change Admin role setting.");
            return RedirectToPage("/Roles/Index");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingWithSameName = await roleManager.FindByNameAsync(Input.Name);
        if (existingWithSameName != null && existingWithSameName.Id != role.Id)
        {
            ModelState.AddModelError("Input.Name", $"Role '{Input.Name}' already exists.");
            return Page();
        }

        role.Name = Input.Name;
        var updateResult = await roleManager.UpdateAsync(role);
        if (!updateResult.Succeeded)
        {
            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        // Sync Description Claim
        var claims = await roleManager.GetClaimsAsync(role);
        var descClaim = claims.FirstOrDefault(c => c.Type == "Description");
        if (descClaim != null)
        {
            await roleManager.RemoveClaimAsync(role, descClaim);
        }
        if (!string.IsNullOrWhiteSpace(Input.Description))
        {
            await roleManager.AddClaimAsync(role, new Claim("Description", Input.Description));
        }

        // Sync Permission Claims
        var existingPermClaims = claims.Where(c => c.Type == "Permission").ToList();
        foreach (var claim in existingPermClaims)
        {
            await roleManager.RemoveClaimAsync(role, claim);
        }

        if (Input.SelectedPermissions.Count > 0)
        {
            foreach (var perm in Input.SelectedPermissions)
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
            }
        }

        NotifySuccess("User role updated successfully.");
        return RedirectToPage("/Roles/Index");
    }
}
