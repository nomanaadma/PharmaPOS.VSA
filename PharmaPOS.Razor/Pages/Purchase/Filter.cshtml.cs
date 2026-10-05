using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Purchases.Queries.ListFilteredPurchases;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Helpers;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Purchase;

[Authorize(Policy = Permissions.Purchase.List)]
public class FilterModel(ISender sender) : PageModel
{
    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        var request = Request.Form.ToDataTableRequest();
	
        var result = await sender.Send(new ListFilteredPurchasesQuery(request, PurchaseColumns.GetColumnMap()), ct);

        var canView = User.HasClaim("Permission", Permissions.Purchase.View);
        var canEdit = User.HasClaim("Permission", Permissions.Purchase.Edit);
        var canDelete = User.HasClaim("Permission", Permissions.Purchase.Delete);

        var formattedData = PurchaseMapper.MapToPurchases(result.Data, canView, canEdit, canDelete);

        return new JsonResult(new
        {
            draw = request.Draw,
            recordsTotal = result.TotalRecords,
            recordsFiltered = result.FilteredRecords,
            data = formattedData
        });
    }
}
