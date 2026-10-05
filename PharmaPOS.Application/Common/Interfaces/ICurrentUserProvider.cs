namespace PharmaPOS.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
	CurrentUser GetCurrentUser();
}

public record CurrentUser(
	string Id,
	IReadOnlyList<string> Permissions,
	IReadOnlyList<string> Roles);
