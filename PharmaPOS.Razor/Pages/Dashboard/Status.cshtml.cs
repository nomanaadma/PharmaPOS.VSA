using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PharmaPOS.Razor.Pages.Dashboard;

[AllowAnonymous]
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class StatusModel : PageModel
{
    public int Code { get; set; }

    public void OnGet(int code)
    {
        Code = code;
    }
    
    public void OnPost(int code)
    {
        Code = code;
    }
}
