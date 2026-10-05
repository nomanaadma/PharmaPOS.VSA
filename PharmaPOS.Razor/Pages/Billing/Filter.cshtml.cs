using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Billings.Queries.ListFilteredBills;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Helpers;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Billing;

[Authorize(Policy = Permissions.Billing.List)]
public class FilterModel(ISender sender) : PageModel
{
    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        var request = Request.Form.ToDataTableRequest();

        var result = await sender.Send(new ListFilteredBillsQuery(request, BillColumns.GetColumnMap()), ct);

        var canView = User.HasClaim("Permission", Permissions.Billing.View);
        var canEdit = User.HasClaim("Permission", Permissions.Billing.Edit);
        var canDelete = User.HasClaim("Permission", Permissions.Billing.Delete);

        var formattedData = BillingMapper.MapToBills(result.Data, canView, canEdit, canDelete);

        return new JsonResult(new
        {
            draw = request.Draw,
            recordsTotal = result.TotalRecords,
            recordsFiltered = result.FilteredRecords,
            data = formattedData
        });
    }
}
