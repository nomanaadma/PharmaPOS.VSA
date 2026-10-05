using ErrorOr;

namespace PharmaPOS.Application.Settings;

public static class SettingsApplicationErrors
{
	
	public static readonly Error NotFound =
		Error.NotFound("Media.NotFound", description: "File is wrong or does not exist.");
	
	public static readonly Error NoFile =
		Error.Validation("Media.NoFile", description: "No file uploaded.");

	public static Error CannotDelete(string name, string msg) =>
		Error.Failure("Media.CannotDelete", description: "Error deleting " + name + ": " + msg);
	
}