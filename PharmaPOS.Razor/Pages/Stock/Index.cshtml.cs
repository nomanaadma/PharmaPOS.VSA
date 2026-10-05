using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Stock.Commands.DeleteStock;
using PharmaPOS.Application.Stock.Commands.UpdateStock;
using PharmaPOS.Application.Stock.Queries.ListStock;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Mappers;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Stock;

[Authorize(Policy = Permissions.Stock.View)]
public class IndexModel(ISender sender) : BasePageModel
{
    public IEnumerable<BatchResponse> Stocks { get; set; } = new List<BatchResponse>();

    public async Task<IActionResult> OnGetAsync(string? type, CancellationToken ct)
    {
        Stocks = await sender.Send(new ListStockQuery(type), ct);

        var pageTitle = type switch
        {
            "expired" => "Expired Stock",
            "willexpirein1" => "Expire in 1 Month",
            "willexpirein2" => "Expire in 2 Month",
            "willexpirein3" => "Expire in 3 Month",
            "willexpirein6" => "Expire in 6 Month",
            _ => "Live Stock"
        };
        
        ViewData["DeleteMsg"] = "Stock will be removed from Inventory.";
        ViewData["Title"] = pageTitle;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateAsync(int id, int medicineId, decimal available, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Stock.View);
        if (!hasPermission)
            return Forbid();
            
        var refererUrl = Request.Headers.Referer.ToString();
        if (string.IsNullOrEmpty(refererUrl))
        {
            refererUrl = "/Medicine/Stock";
        }
        
        var result = await sender.Send(new UpdateStockCommand(id, medicineId, available), ct);

        if (result.IsError)
        {
            NotifyWarning(result.Errors[0].Description);
            return Redirect(refererUrl);
        }

        NotifySuccess("Stock updated successfully!");
        return Redirect(refererUrl);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Stock.Delete);
        if (!hasPermission)
            return Forbid();
            
        var refererUrl = Request.Headers.Referer.ToString();
        if (string.IsNullOrEmpty(refererUrl))
        {
            refererUrl = "/Medicine/Stock";
        }

        var result = await sender.Send(new DeleteStockCommand(id), ct);
        
        if (result.IsError)
        {
            NotifyWarning(result.Errors[0].Description);
            return Redirect(refererUrl);
        }
        
        NotifySuccess("Medicine Stock deleted successfully.");
        return Redirect(refererUrl);
    }
}
