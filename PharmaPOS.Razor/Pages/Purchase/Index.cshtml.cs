using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Purchases.Commands.DeletePurchase;

namespace PharmaPOS.Razor.Pages.Purchase;

[Authorize(Policy = Permissions.Purchase.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Purchase.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeletePurchaseCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Purchase deleted successfully.");
        return RedirectToPage();
    }
}
