using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PharmaPOS.Application.Common.Interfaces;

namespace PharmaPOS.Infrastructure.Common.Services;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
	public CurrentUser GetCurrentUser()
	{
		var user = httpContextAccessor.HttpContext?.User
			?? throw new InvalidOperationException("No authenticated user found.");

		var id = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

		var permissions = user.Claims
			.Where(c => c.Type == "Permission")
			.Select(c => c.Value)
			.ToList()
			.AsReadOnly();

		var roles = user.Claims
			.Where(c => c.Type == ClaimTypes.Role)
			.Select(c => c.Value)
			.ToList()
			.AsReadOnly();

		return new CurrentUser(id, permissions, roles);
	}
}
