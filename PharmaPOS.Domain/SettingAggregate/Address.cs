namespace PharmaPOS.Domain.SettingAggregate;


public record Address
{
	private Address() { } // Still needed for EF Core

	public Address(string? line1, string? line2, string? city, string? country, string? postal)
	{
		Line1 = line1;
		Line2 = line2;
		City = city;
		Country = country;
		Postal = postal;
	}

	public string? Line1 { get; private set; }
	public string? Line2 { get; private set; }
	public string? City { get; private set; }
	public string? Country { get; private set; }
	public string? Postal { get; private set; }

	public static Address Empty => new(null, null, null, null, null);
	
}
