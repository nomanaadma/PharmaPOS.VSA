using ErrorOr;
using PharmaPOS.Domain.Common.Errors;

namespace PharmaPOS.Domain.Common;

public static class DomainValidator<T>
{
	public static void ValidateRequiredStrings(
		List<Error> errors, 
		params (string? Value, string FieldName)[] fields)
	{
		foreach (var (value, fieldName) in fields)
		{
			if (string.IsNullOrWhiteSpace(value))
				errors.Add(CommonErrors<T>.Required(fieldName));
		}
	}

	public static void ValidateIds(
		List<Error> errors, 
		params (long Value, string FieldName)[] fields)
	{
		foreach (var (value, fieldName) in fields)
		{
			if (value <= 0)
				errors.Add(CommonErrors<T>.InvalidId(fieldName));
		}
	}

	public static void ValidateNonNegativeNumbers(
		List<Error> errors, 
		params (decimal Value, string FieldName)[] fields)
	{
		foreach (var (value, fieldName) in fields)
		{
			if (value < 0)
				errors.Add(CommonErrors<T>.InvalidNumber(fieldName));
		}
	}
	
	public static void ValidateEnums(
		List<Error> errors, 
		params (Enum Value, string FieldName)[] fields)
	{
		foreach (var (value, fieldName) in fields)
		{
			// Dynamically gets the exact enum type (e.g., typeof(Gender) or typeof(Status))
			if (!Enum.IsDefined(value.GetType(), value))
				errors.Add(CommonErrors<T>.InvalidEnum(fieldName));
		}
	}
}