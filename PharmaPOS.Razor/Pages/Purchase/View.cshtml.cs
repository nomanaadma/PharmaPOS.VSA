using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Purchases.Queries.GetPurchase;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Purchase;

[Authorize(Policy = Permissions.Purchase.View)]
public class ViewModel(ISender sender) : BasePageModel
{
	public PurchaseResponse Purchase { get; set; } = null!;
	
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetPurchaseQuery(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        Purchase = result.Value;
        return Page();
    }
}
