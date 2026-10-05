using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Purchases.Commands.CreatePurchase;
using PharmaPOS.Application.Suppliers.Queries.ListSuppliersLookup;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Purchase;

[Authorize(Policy = Permissions.Purchase.Add)]
public class AddModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public PurchaseFormModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Input.Suppliers = (await sender.Send(new ListSuppliersLookupQuery(), ct)).ToSelectList();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Input.Suppliers = (await sender.Send(new ListSuppliersLookupQuery(), ct)).ToSelectList();
        
        if (!ModelState.IsValid)
        {
            NotifyError("Please check your inputs.");
            return Page();
        }
        
        var request = Input.Adapt<PurchaseRequest>();
        
        var result = await sender.Send(new CreatePurchaseCommand(request), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);

        NotifySuccess("Purchase created successfully.");
        return RedirectToPage("/Purchase/Index");
    }
}
