using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Infrastructure.Common.Persistence;

public class DbInitializer(
		RoleManager<IdentityRole> roleManager,
		UserManager<IdentityUser> userManager
	)
{
	public async Task SeedAuthDataAsync()
	{
		// 1. Define and Create Roles
		string[] roles = [
			Roles.Admin,
			Roles.StoreManager,
			Roles.Employee,
		];
		
		foreach (var roleName in roles)
		{
			if (!await roleManager.RoleExistsAsync(roleName))
			{	
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}

		// 2. Define Exact Permission Arrays
		var adminPermissions = Permissions.GetAll();
		
		var storeManagerPermissions = Permissions.Get(
			typeof(Permissions.Dashboard),
			typeof(Permissions.Customer),
			typeof(Permissions.Billing),
			typeof(Permissions.Purchase),
			typeof(Permissions.Stock),
			typeof(Permissions.Medicine),
			typeof(Permissions.Category),
			typeof(Permissions.PaymentMethod),
			typeof(Permissions.Media)
		);
		
		var employeePermissions = Permissions.Get(
			typeof(Permissions.Dashboard),
			typeof(Permissions.Customer),
			typeof(Permissions.Billing)
		);

		// 3. Assign Permissions as Claims to Roles
		await SyncRolePermissions(Roles.Admin, adminPermissions);
		await SyncRolePermissions(Roles.StoreManager, storeManagerPermissions);
		await SyncRolePermissions(Roles.Employee, employeePermissions);

		// 4. Create the Default Admin User
		const string adminEmail = "nomanaadma@gmail.com";
		var adminUser = await userManager.FindByEmailAsync(adminEmail);

		if (adminUser == null)
		{
			adminUser = new IdentityUser
			{
				UserName = adminEmail,
				Email = adminEmail,
				EmailConfirmed = true
			};

			var createResult = await userManager.CreateAsync(adminUser, "$upeEam#@!f0");
			if (createResult.Succeeded)
			{
				await userManager.AddToRoleAsync(adminUser, Roles.Admin);
			}
		}
	}

	private async Task SyncRolePermissions(string roleName, string[] permissions)
	{
		// 1. Fetch the role using the manager. This registers it cleanly in the current tracking scope.
		var role = await roleManager.FindByNameAsync(roleName);
		if (role == null) return;

		// 2. Safely extract the existing claims without detaching or re-attaching the role object.
		var existingClaims = await roleManager.GetClaimsAsync(role);

		foreach (var permission in permissions)
		{
			// 3. Check if the claim already exists to keep operation idempotent
			if (existingClaims.Any(c => c.Type == "Permission" && c.Value == permission)) continue;
			// 4. Use the native RoleManager API to inject the claim. 
			// This safely manages the state context internally without causing tracking collisions.
			var result = await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            
			if (!result.Succeeded)
			{
				throw new Exception($"Failed to add permission '{permission}' to role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
			}
		}
	}
}
