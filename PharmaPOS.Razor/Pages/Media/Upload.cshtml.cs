using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Settings.Commands.UploadMediaFile;

namespace PharmaPOS.Razor.Pages.Media;

[Authorize(Policy = Permissions.Media.Upload)]
[IgnoreAntiforgeryToken]
public class UploadModel(ISender sender) : PageModel
{
    public async Task<IActionResult> OnPostAsync(IFormFile? file, CancellationToken ct)
    {
        if (file == null || file.Length == 0)
        {
            return new JsonResult(new { error = true, message = "No file uploaded." });
        }

        await using var stream = file.OpenReadStream();
        var uploadResult = await sender.Send(new UploadMediaFileCommand(stream, file.FileName, file.Length), ct);
        if (uploadResult.IsError)
            return new JsonResult(new { error = true, message = uploadResult.Errors[0].Description });

        var (id, filename, width, height) = uploadResult.Value;
        
        var canDelete = User.HasClaim("Permission", Permissions.Media.Delete);

        var deleteHtml = canDelete
            ? """<a class="remove" data-toggle="tooltip" data-placement="top" title="Remove"><i class="las la-trash-alt"></i></a>"""
            : string.Empty;

        var mediaHtml = $"""
                         <div class="block">
                             {deleteHtml}
                             <input type="radio" class="block-id" value="{id}">
                             <div class="picture">
                                 <img src="/uploads/{filename}" title="{filename}">
                                 <input type="radio" id="{filename}" value="{filename}">
                                 <label for="{filename}">{filename}</label>
                             </div>
                             <label class="font-12">Image Size : {width}*{height}</label>
                         </div>
                         """;

        return new JsonResult(new { error = false, name = filename, id, media = mediaHtml });
    }
}
