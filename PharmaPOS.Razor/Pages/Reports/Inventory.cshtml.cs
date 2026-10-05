using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Reports.Queries.ListInventoryReport;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Reports;

[Authorize(Policy = Permissions.Reports.View)]
public class InventoryModel(ISender sender) : BasePageModel
{
    public IEnumerable<InventoryReportResponse> Inventory { get; set; } = new List<InventoryReportResponse>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
	    Inventory = await sender.Send(new ListInventoryReportQuery(), ct);
        return Page();
    }
}
