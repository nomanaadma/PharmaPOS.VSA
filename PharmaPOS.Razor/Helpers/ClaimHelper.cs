using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PharmaPOS.Razor.Helpers;

public static class ClaimHelper
{
	public static async Task UpdateOrCreateClaimAsync(
		string claimType, 
		string newValue,
		IList<Claim> existingClaims,
		UserManager<IdentityUser> userManager, 
		IdentityUser user
		)
	{
		var existingClaim = existingClaims.FirstOrDefault(c => c.Type == claimType);

		if (existingClaim != null)
		{
			// Only hit the database if the value actually changed
			if (existingClaim.Value != newValue)
			{
				await userManager.ReplaceClaimAsync(user, existingClaim, new Claim(claimType, newValue));
			}
		}
		else
		{
			await userManager.AddClaimAsync(user, new Claim(claimType, newValue));
		}
	}
}