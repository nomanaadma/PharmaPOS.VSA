using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Billings.Queries.ListRecentBills;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Customers.Queries.GetCustomer;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Customers;

[Authorize(Policy = Permissions.Customer.View)]
public class ViewModel(ISender sender) : BasePageModel
{
	public CustomerResponse Customer { get; set; } = null!;
    public IEnumerable<CustomerBillsResponse> RecentBills { get; set; } = new List<CustomerBillsResponse>();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetCustomerQuery(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        var customer = result.Value;
        var recentBills = await sender.Send(new ListRecentBillsQuery(customer.Id, customer.Email), ct);

        Customer = customer;
        RecentBills = recentBills;

        return Page();
    }
}
