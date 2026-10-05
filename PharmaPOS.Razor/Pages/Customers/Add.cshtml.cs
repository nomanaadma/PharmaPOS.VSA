using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Customers.Commands.CreateCustomer;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Customers;

[Authorize(Policy = Permissions.Customer.Add)]
public class AddModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public CustomerViewModel Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<CustomerRequest>();

        var result = await sender.Send(new CreateCustomerCommand(request), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, new() { ["Customer.EmailNotUnique"] = "Input.Email" });

        NotifySuccess("Customer created successfully.");
        return RedirectToPage("/Customers/Index");
    }
}
