using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Customers.Commands.DeleteCustomer;
using PharmaPOS.Application.Customers.Queries.ListCustomers;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Customers;

[Authorize(Policy = Permissions.Customer.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public IEnumerable<CustomerResponse> Customers { get; set; } = new List<CustomerResponse>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var customers = await sender.Send(new ListCustomersQuery(), ct);
        Customers = customers;
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Customer.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeleteCustomerCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Customer deleted successfully.");
        return RedirectToPage();
    }
}
