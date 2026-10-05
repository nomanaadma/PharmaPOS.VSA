using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Reports.Queries.GetIncomeExpenseReport;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Reports;

[Authorize(Policy = Permissions.Reports.View)]
public class IncomeExpenseModel(ISender sender) : BasePageModel
{
	
	[BindProperty(SupportsGet = true)]
	public InventoryReportRequest Filter { get; set; } = new();

	public StatsReportResponse Stats { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(InventoryReportRequest request, CancellationToken ct)
    {
	    Stats = await sender.Send(new GetIncomeExpenseReportQuery(request), ct);
        return Page();
    }
}
