namespace PharmaPOS.Razor.Extensions;

public static class DateExtensions
{
	extension(DateTime datetime)
	{
		public string Format()
		{
			return datetime.ToString("dd/MM/yyyy");
		}

		public string ExpiryFormat()
		{
			return datetime.ToString("yyyyMM");
		}
		
		public string ExpiryVisibleFormat()
		{
			return datetime.ToString("MM-yyyy");
		}
		
	}
}