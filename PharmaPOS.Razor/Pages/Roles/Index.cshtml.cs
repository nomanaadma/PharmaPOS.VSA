using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;
using UserRole = PharmaPOS.Application.Common.Authorization.Roles;

namespace PharmaPOS.Razor.Pages.Roles;

[Authorize(Roles = UserRole.Admin)]
public class IndexModel(RoleManager<IdentityRole> roleManager) : BasePageModel
{
    public IEnumerable<RoleListViewModel> Roles { get; set; } = new List<RoleListViewModel>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var roles = await roleManager.Roles.OrderBy(r => r.Name).ToListAsync(ct);
        var list = new List<RoleListViewModel>();

        foreach (var role in roles)
        {
            var claims = await roleManager.GetClaimsAsync(role);
            var description = claims.GetClaim("Description");

            var createdDateClaim = claims.GetClaim("CreatedDate");
            
            var createdDate = "";
            if (!string.IsNullOrWhiteSpace(createdDateClaim) && DateTime.TryParse(createdDateClaim, out var parsedDate))
            {
                createdDate = parsedDate.Format();
            }

            list.Add(new RoleListViewModel
            {
                Id = role.Id,
                Name = role.Name ?? "",
                Description = description,
                CreatedDate = createdDate,
            });
            
        }
        
        Roles = list;
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            NotifyError("Role ID is missing!");
            return RedirectToPage();
        }

        var role = await roleManager.FindByIdAsync(id);
        if (role == null)
        {
            NotifyWarning("Role does not exist in database!");
            return RedirectToPage();
        }

        if (role.Name == UserRole.Admin)   
        {
            NotifyError("Admin role cannot be deleted!");
            return RedirectToPage();
        }

        var result = await roleManager.DeleteAsync(role);
        if (result.Succeeded)
        {
            NotifySuccess("User Role deleted successfully.");
        }
        else
        {
            NotifyError("Error deleting role: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        return RedirectToPage();
    }
}
