using ErrorOr;

namespace PharmaPOS.Application.PaymentMethods;

public static class PaymentMethodApplicationErrors
{
	public static readonly Error NameNotUnique =
		Error.Conflict("PaymentMethod.NameNotUnique", "Payment Method Name must be unique.");
}
