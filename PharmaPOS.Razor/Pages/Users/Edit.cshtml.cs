using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Helpers;
using PharmaPOS.Shared.Enums;
using static System.Enum;

namespace PharmaPOS.Razor.Pages.Users;

[Authorize(Policy = Permissions.User.Edit)]
public class EditModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : BasePageModel
{
    [BindProperty]
    public UserFormViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string id, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return RedirectToPage("/Users/Index");
        }

        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            NotifyWarning("User does not exist in database!");
            return RedirectToPage("/Users/Index");
        }

        var claims = await userManager.GetClaimsAsync(user);
        var roleName = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "";
        
        var isLockedOut = user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow;
        var status = (isLockedOut) ? Status.InActive : Status.Active;
        
        var firstName = claims.GetClaim(ClaimTypes.GivenName);
        var lastName = claims.GetClaim(ClaimTypes.Surname);
        
        var genderStr = claims.GetClaim("Gender", nameof(Gender.NotSpecified));
        
        var genderFound = TryParse<Gender>(genderStr, out var genderEnum);

        if (!genderFound)
        {
            genderEnum = Gender.NotSpecified;
        }

        Input = new UserFormViewModel
        {
            UserId = user.Id,
            FirstName = firstName,
            LastName = lastName,
            Mobile = user.PhoneNumber ?? "",
            Email = user.Email ?? "",
            Gender = genderEnum,
            Status = status,
            UserRole = roleName,
            UserName = user.UserName ?? "",
            Roles = await GetRolesSelectListAsync(ct)
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id, CancellationToken ct)
    {
        if (id != Input.UserId)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        Input.Roles = await GetRolesSelectListAsync(ct);

        if (string.IsNullOrWhiteSpace(Input.UserId))
        {
            return RedirectToPage("/Users/Index");
        }

        var user = await userManager.FindByIdAsync(Input.UserId);
        if (user == null)
        {
            NotifyWarning("User does not exist in database!");
            return RedirectToPage("/Users/Index");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Check username uniqueness
        var existingByUsername = await userManager.FindByNameAsync(Input.UserName);
        if (existingByUsername != null && existingByUsername.Id != user.Id)
        {
            ModelState.AddModelError("Input.UserName", $"User Name {Input.UserName} already exists in database.");
            return Page();
        }

        // Check email uniqueness
        var existingByEmail = await userManager.FindByEmailAsync(Input.Email);
        if (existingByEmail != null && existingByEmail.Id != user.Id)
        {
            ModelState.AddModelError("Input.Email", $"Email {Input.Email} already exists in database.");
            return Page();
        }

        user.UserName = Input.UserName;
        user.Email = Input.Email;
        user.PhoneNumber = Input.Mobile;

        // Update Lockout status
        if (Input.Status == Status.InActive)
        {
            await userManager.SetLockoutEnabledAsync(user, true);
            await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
        }
        else
        {
            await userManager.SetLockoutEndDateAsync(user, null);
        }

        var updateResult = await userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        // Sync Claims
        var claims = await userManager.GetClaimsAsync(user);
        
        await ClaimHelper.UpdateOrCreateClaimAsync(ClaimTypes.GivenName, Input.FirstName, claims, userManager, user);
        await ClaimHelper.UpdateOrCreateClaimAsync(ClaimTypes.Surname, Input.LastName, claims, userManager, user);
        await ClaimHelper.UpdateOrCreateClaimAsync("Gender", Input.Gender.ToString(), claims, userManager, user);

        // Sync Role
        if (!string.IsNullOrWhiteSpace(Input.UserRole) && await roleManager.RoleExistsAsync(Input.UserRole))
        {
            var currentRoles = await userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(Input.UserRole))
            {
                await userManager.RemoveFromRolesAsync(user, currentRoles);
                await userManager.AddToRoleAsync(user, Input.UserRole);
            }
        }

        NotifySuccess("Account updated successfully.");
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
