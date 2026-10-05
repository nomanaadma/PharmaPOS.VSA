using ErrorOr;

namespace PharmaPOS.Application.Customers;

public static class CustomerApplicationErrors
{
	public static readonly Error EmailNotUnique =
		Error.Conflict("Customer.EmailNotUnique", "Email Address must be unique.");
	
	public static readonly Error CannotDeleteWithBills =
		Error.Conflict("Customer.CannotDelete", "Cannot delete a customer that has associated bills.");
}
