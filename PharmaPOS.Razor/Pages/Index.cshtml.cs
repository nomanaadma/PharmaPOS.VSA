using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Razor.Pages;

[Authorize(Policy = Permissions.Dashboard.View)]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
