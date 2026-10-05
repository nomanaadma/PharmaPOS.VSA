using System.Security.Claims;

namespace PharmaPOS.Razor.Extensions;

public static class ClaimsExtensions
{
    public static bool HasPermission(this ClaimsPrincipal user, string permissionKey)
    {
	    return user.Identity is { IsAuthenticated: true } && user.HasClaim(c => c.Type == "Permission" && c.Value == permissionKey);
    }

    public static string GetClaim(this IEnumerable<Claim> claims, string claimKey, string defaultValue = "")
    {
	    return claims.FirstOrDefault(c => c.Type == claimKey)?.Value ?? defaultValue;
    }
    
}
