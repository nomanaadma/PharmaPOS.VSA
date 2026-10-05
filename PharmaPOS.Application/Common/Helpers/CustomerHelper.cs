using PharmaPOS.Contracts.Requests;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Application.Common.Helpers;

public static class CustomerHelper
{
    public static CustomerRequest CreateCustomerRequest(BillingRequest billingRequest)
    {
        var nameParts = (billingRequest.Name).Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Default to empty strings if the array is empty
        var lastName = nameParts.Length > 0 ? nameParts[^1] : string.Empty;

        var firstName = nameParts.Length > 1 
            ? string.Join(" ", nameParts[..^1]) 
            : lastName;
        
        return new CustomerRequest(
            Id: billingRequest.CustomerId,
            FirstName: firstName,
            LastName: lastName,
            Email: billingRequest.Email,
            Mobile: billingRequest.Mobile,
            Gender: Gender.NotSpecified,
            Status: Status.Active
        );
    }
}
