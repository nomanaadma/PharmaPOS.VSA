using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Medicines.Queries.SearchMedicines;

namespace PharmaPOS.Razor.Pages.Medicines;

public class GetMedicineModel(ISender sender) : PageModel
{
    public async Task<IActionResult> OnGetAsync(string term, CancellationToken ct)
    {
        var canBillingAdd = User.HasClaim("Permission", Permissions.Billing.Add);
        var canBillingEdit = User.HasClaim("Permission", Permissions.Billing.Edit);
        var canPurchaseAdd = User.HasClaim("Permission", Permissions.Purchase.Add);
        var canPurchaseEdit = User.HasClaim("Permission", Permissions.Purchase.Edit);
        var canReportView = User.HasClaim("Permission", Permissions.Purchase.Edit); // Matching the logic from MVC
        
        if (!canBillingAdd && !canBillingEdit && !canPurchaseAdd && !canPurchaseEdit && !canReportView)
        {
            return Forbid();
        }
        
        if (string.IsNullOrWhiteSpace(term))
        {
            return new JsonResult(Array.Empty<object>());
        }

        var results = await sender.Send(new SearchMedicinesQuery(term), ct);

        return new JsonResult(results);
    }
}
