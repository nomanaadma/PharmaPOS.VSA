using ErrorOr;

namespace PharmaPOS.Application.Stock;

public static class StockApplicationErrors
{
	public static readonly Error NotFound =
		Error.NotFound("Stock.NotFound", description: "Stock does not exist in database!");
}