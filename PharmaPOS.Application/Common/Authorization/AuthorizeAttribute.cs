namespace PharmaPOS.Application.Common.Authorization;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AuthorizeCommandAttribute : Attribute
{
	public string? Permissions { get; set; }
	public string? Roles { get; set; }
}
