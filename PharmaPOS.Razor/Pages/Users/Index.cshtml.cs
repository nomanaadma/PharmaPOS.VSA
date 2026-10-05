using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;
using PharmaPOS.Shared.Enums;
using UserRole = PharmaPOS.Application.Common.Authorization.Roles;

namespace PharmaPOS.Razor.Pages.Users;

[Authorize(Policy = Permissions.User.List)]
public class IndexModel(UserManager<IdentityUser> userManager) : BasePageModel
{
    public IEnumerable<UserListViewModel> Users { get; set; } = new List<UserListViewModel>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var users = await userManager.Users.ToListAsync(ct);
        var userList = new List<UserListViewModel>();

        foreach (var user in users)
        {
            var claims = await userManager.GetClaimsAsync(user);
            var roleName = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "No Role";
            
            var fullName = claims.GetClaim(ClaimTypes.GivenName) + " " +  claims.GetClaim(ClaimTypes.Surname);
            
            var createdDate = claims.GetClaim("CreatedDate");
            
            var isLockedOut = user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow;
            
            var status = (isLockedOut) ? Status.InActive : Status.Active;

            userList.Add(new UserListViewModel
            {
                Id = user.Id,
                FullName = fullName, 
                Email = user.Email ?? "",
                Mobile = user.PhoneNumber ?? "",
                UserName = user.UserName ?? "",
                Role = roleName,
                CreatedDate = createdDate,
                Status = status
            });
        }
        
        Users = userList.OrderByDescending(u => u.CreatedDate).ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.User.Delete);
        if (!hasPermission)
            return Forbid();

        if (string.IsNullOrWhiteSpace(id))
        {
            NotifyError("User ID is missing!");
            return RedirectToPage();
        }

        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            NotifyWarning("User does not exist in database!");
            return RedirectToPage();
        }

        // Prevent deleting Primary Admin or Self
        var currentUserId = userManager.GetUserId(User);
        if (user.Id == currentUserId)
        {
            NotifyError("You cannot delete your own account!");
            return RedirectToPage();
        }
        
        var roleName = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "No Role";

        if (roleName == UserRole.Admin)
        {
            NotifyError("Administrator account cannot be deleted!");
            return RedirectToPage();
        }

        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            NotifySuccess("Account deleted successfully.");
        }
        else
        {
            NotifyError("Error deleting account: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        return RedirectToPage();
    }
}
