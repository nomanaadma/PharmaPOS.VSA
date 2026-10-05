namespace PharmaPOS.Razor.Extensions;

public static class CurrencyExtensions
{
	public const string Currency = "Rs ";
	
	extension(decimal value)
	{
		public string ToCrF2()
		{
			return Currency + value.ToString("F2");
		}

		public string ToCrHash()
		{
			return Currency + value.ToZeroHash();
		}

		public string ToZeroHash()
		{
			return value.ToString("0.##");
		}
		
	}
}