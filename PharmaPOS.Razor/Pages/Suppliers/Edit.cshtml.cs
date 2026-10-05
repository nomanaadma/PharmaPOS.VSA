using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Suppliers.Commands.UpdateSupplier;
using PharmaPOS.Application.Suppliers.Queries.GetSupplier;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Suppliers;

[Authorize(Policy = Permissions.Suppliers.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public SupplierViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetSupplierQuery(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors);

        Input = result.Value.Adapt<SupplierViewModel>();
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
            NotifyError("Supplier ID is required for editing.");
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<SupplierRequest>();

        var result = await sender.Send(new UpdateSupplierCommand(id, request), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, new() { ["Supplier.EmailNotUnique"] = "Input.Email" });

        NotifySuccess("Supplier updated successfully.");
        return RedirectToPage("/Suppliers/Index");
    }
}
