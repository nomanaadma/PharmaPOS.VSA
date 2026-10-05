using ErrorOr;

namespace PharmaPOS.Domain.Common.Errors;

public static class CommonErrors<T>
{
	private static readonly string Prefix = typeof(T).Name;

	public static Error Required(string fieldName) =>
		Error.Validation($"{Prefix}.{fieldName}Required", $"{fieldName} is required.");

	public static Error InvalidId(string fieldName, string? customMessage = null) =>
		Error.Validation($"{Prefix}.Invalid{fieldName}", customMessage ?? $"A valid {fieldName} is required.");
	
	public static Error InvalidNumber(string fieldName, string? customMessage = null) =>
		Error.Validation($"{Prefix}.Invalid{fieldName}", customMessage ?? $"{fieldName} cannot be negative.");
	
	public static Error InvalidEnum(string fieldName, string? customMessage = null) =>
		Error.Validation($"{Prefix}.Invalid{fieldName}", customMessage ?? $"Invalid {fieldName} value.");
	
	public static Error NotFound(int id, string? customMessage = null) => 
		Error.NotFound($"{Prefix}.NotFound", customMessage ?? $"{Prefix} {id} doest not existss.");
	
}
