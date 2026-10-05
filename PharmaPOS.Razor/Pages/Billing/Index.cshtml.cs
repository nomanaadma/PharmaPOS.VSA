using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Billings.Commands.DeleteBill;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Razor.Pages.Billing;

[Authorize(Policy = Permissions.Billing.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public void OnGet()
    {
        ViewData["DeleteMsg"] = "Inventory will be updated and those Stock will be added in Inventory.";
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Billing.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeleteBillCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Bill deleted successfully.");
        return RedirectToPage();
    }
}
