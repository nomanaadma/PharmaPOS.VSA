using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Application.Settings.Queries.ListMedia;

namespace PharmaPOS.Razor.Pages.Media;

[Authorize(Policy = Permissions.Media.List)]
public class GetModel(IFilePathProvider pathProvider, ISender sender) : PageModel
{
    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var result = await sender.Send(new ListMediaQuery(), ct);
        var html = "";
        
        foreach (var value in result)
        {
            var filePath = pathProvider.GetUploadsFilePath(value.Filename);
            var (width, height) = ImageHelper.GetImageDimensions(filePath);

            html += $"""
             <div class="block">
             <a class="remove" data-toggle="tooltip" data-placement="top" title="Remove"><i class="las la-trash-alt"></i></a>
             <input type="hidden" class="block-id" value="{value.Id}">
             <div class="picture">
             <img src="/uploads/{value.Filename}" title="{value.Filename}">
             <input type="radio" id="{value.Filename}" value="{value.Filename}">
             <label for="{value.Filename}">{value.Filename}</label>
             </div>
             <label class="font-12">Image Size : {width}*{height}</label>
             </div>
             """;
        }

        return Content(html, "text/html");
    }
}
