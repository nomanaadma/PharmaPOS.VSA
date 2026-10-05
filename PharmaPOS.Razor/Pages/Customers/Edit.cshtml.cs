using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Customers.Commands.UpdateCustomer;
using PharmaPOS.Application.Customers.Queries.GetCustomer;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Customers;

[Authorize(Policy = Permissions.Customer.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public CustomerViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetCustomerQuery(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors);

        Input = result.Value.Adapt<CustomerViewModel>();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken ct)
    {
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        if (Input.Id == 0)
        {
            NotifyError("Customer ID is required for editing.");
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<CustomerRequest>();

        var result = await sender.Send(new UpdateCustomerCommand(id, request), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, new() { ["Customer.EmailNotUnique"] = "Input.Email" });

        NotifySuccess("Customer updated successfully.");
        return RedirectToPage("/Customers/Index");
    }
}
