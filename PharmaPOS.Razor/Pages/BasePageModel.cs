using System.Text.Json;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PharmaPOS.Razor.Pages;

public abstract class BasePageModel : PageModel
{
    public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        var isRedirect = context.Result is RedirectResult or RedirectToActionResult or RedirectToRouteResult or LocalRedirectResult or RedirectToPageResult;

        var setInCurrentRequest = HttpContext.Items.ContainsKey("NotifyMessageCurrentRequest");

        if (!isRedirect && setInCurrentRequest)
        {
            TempData.Remove("Message");
        }

        base.OnPageHandlerExecuted(context);
    }
    
    private void Notify(string alert, string message)
    {
        var msg = JsonSerializer.Serialize(new { alert, value = message });
        HttpContext.Items["NotifyMessage"] = msg;
        HttpContext.Items["NotifyMessageCurrentRequest"] = true;
        TempData["Message"] = msg;
    }
    
    protected void NotifySuccess(string message)
    {
        Notify("success", message);
    }

    protected void NotifyError(string message)
    {
        Notify("error", message);
    }

    protected void NotifyWarning(string message)
    {
        Notify("warning", message);
    }

    protected IActionResult HandleErrors(
        List<Error> errors,
        Dictionary<string, string>? conflictFieldMap = null,
        bool redirectOnError = false)
    {
        var firstError = errors[0];

        switch (firstError.Type)
        {
            case ErrorType.NotFound:
                NotifyWarning(firstError.Description);
                return NotFound();

            case ErrorType.Validation:
                // Add all validation errors to ModelState
                foreach (var error in errors)
                {
                    // For FluentValidation, Code is usually the PropertyName
                    ModelState.AddModelError($"Input.{error.Code}", error.Description);
                }
                NotifyError("Please check your inputs.");
                return redirectOnError ? RedirectToPage() : Page();

            case ErrorType.Conflict:
                if (conflictFieldMap != null
                    && conflictFieldMap.TryGetValue(firstError.Code, out var fieldName))
                {
                    ModelState.AddModelError(fieldName, firstError.Description);
                }
                else
                {
                    NotifyError(firstError.Description);
                }

                return redirectOnError ? RedirectToPage() : Page();

            case ErrorType.Forbidden:
                NotifyError(firstError.Description);
                return redirectOnError ? RedirectToPage() : Page();

            default:
                NotifyError("An unexpected error occurred. Please try again.");
                return redirectOnError ? RedirectToPage() : Page();
        }
    }
}
