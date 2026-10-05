using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Users;

[Authorize(Policy = Permissions.User.Add)]
public class AddModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : BasePageModel
{
    [BindProperty]
    public UserFormViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Input.Roles = await GetRolesSelectListAsync(ct);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Input.Roles = await GetRolesSelectListAsync(ct);
        
        if (string.IsNullOrWhiteSpace(Input.Password))
        {
            ModelState.AddModelError("Input.Password", "Password is required.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existingByUsername = await userManager.FindByNameAsync(Input.UserName);
        if (existingByUsername != null)
        {
            ModelState.AddModelError("Input.UserName", $"User Name {Input.UserName} already exists in database.");
            return Page();
        }

        var existingByEmail = await userManager.FindByEmailAsync(Input.Email);
        if (existingByEmail != null)
        {
            ModelState.AddModelError("Input.Email", $"Email {Input.Email} already exists in database.");
            return Page();
        }

        var user = new IdentityUser
        {
            UserName = Input.UserName,
            Email = Input.Email,
            PhoneNumber = Input.Mobile,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, Input.Password!);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        // Add Profile Claims
        var claims = new List<Claim>
        {
            new(ClaimTypes.GivenName, Input.FirstName),
            new(ClaimTypes.Surname, Input.LastName),
            new("Gender", Input.Gender.ToString()),
            new("CreatedDate", Input.CreatedDate.Format()),
        };
        await userManager.AddClaimsAsync(user, claims);

        // Assign Role
        if (!string.IsNullOrWhiteSpace(Input.UserRole) && await roleManager.RoleExistsAsync(Input.UserRole))
        {
            await userManager.AddToRoleAsync(user, Input.UserRole);
        }

        NotifySuccess("Account created successfully.");
        return RedirectToPage("/Users/Index");
    }
    
    private async Task<IEnumerable<SelectListItem>> GetRolesSelectListAsync(CancellationToken ct = default)
    {
        var roles = await roleManager.Roles.OrderBy(r => r.Name).ToListAsync(ct);
        return roles.Select(r => new SelectListItem
        {
            Value = r.Name,
            Text = r.Name
        });
    }
}
