using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Billings.Queries.GetBill;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Settings.Queries.GetSettings;

namespace PharmaPOS.Razor.Pages.Billing;

[Authorize(Policy = Permissions.Billing.View)]
public class ViewModel(ISender sender) : BasePageModel
{
    public BillResponse Bill { get; set; } = null!;
    public SettingResponse SiteInfo { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetBillQuery(id), ct);

        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        Bill = result.Value;
        SiteInfo = await sender.Send(new GetSettingsQuery(), ct);
        
        return Page();
    }
}
