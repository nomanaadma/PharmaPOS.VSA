using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Settings.Commands.UpdateSettings;
using PharmaPOS.Application.Settings.Queries.GetRawSettings;
using PharmaPOS.Application.Settings.Queries.GetSettings;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Setting;

[Authorize(Policy = Permissions.Info.View)]
public class IndexModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public SystemInfoViewModel Input { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var rawSetting = await sender.Send(new GetRawSettingsQuery(), ct);
        var siteInfo = await sender.Send(new GetSettingsQuery(), ct);

        Input = SettingMapper.MapToSystemInfo(rawSetting, siteInfo);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            NotifyError("Validation failed: " + errors);
            return Page();
        }

        var request = Input.Adapt<SettingRequest>();

        var result = await sender.Send(new UpdateSettingsCommand(request), ct);
        if (result.IsError)
        {
            NotifyError(result.Errors[0].Description);
            return Page();
        }

        NotifySuccess("System settings updated successfully.");

        return RedirectToPage();
    }
}
