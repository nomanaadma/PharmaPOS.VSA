namespace PharmaPOS.Application.Common.Extensions;

public static class DateExtensions
{
	public static string ExpiryFormat(this DateTime datetime)
	{
		return datetime.ToString("yyyyMM");
	}
}