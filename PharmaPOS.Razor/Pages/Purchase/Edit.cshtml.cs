using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Purchases.Commands.UpdatePurchase;
using PharmaPOS.Application.Purchases.Queries.GetPurchase;
using PharmaPOS.Application.Suppliers.Queries.ListSuppliersLookup;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Purchase;

[Authorize(Policy = Permissions.Purchase.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public PurchaseFormModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetPurchaseQuery(id), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);
        
        var suppliers = (await sender.Send(new ListSuppliersLookupQuery(), ct)).ToSelectList();
        
        Input = result.Value.Adapt<PurchaseFormModel>();
        Input.Suppliers = suppliers;
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken ct)
    {
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        Input.Suppliers = (await sender.Send(new ListSuppliersLookupQuery(), ct)).ToSelectList();

        if (!ModelState.IsValid)
        {
            NotifyError("Please check your inputs.");
            return Page();
        }
        
        var request = Input.Adapt<PurchaseRequest>();

        var result = await sender.Send(new UpdatePurchaseCommand(id, request), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);

        NotifySuccess("Purchase updated successfully.");
        return RedirectToPage("/Purchase/Index");
    }
}
