using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Suppliers.Commands.DeleteSupplier;
using PharmaPOS.Application.Suppliers.Queries.ListSuppliers;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Suppliers;

[Authorize(Policy = Permissions.Suppliers.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public IEnumerable<SupplierResponse> Suppliers { get; set; } = new List<SupplierResponse>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Suppliers = await sender.Send(new ListSuppliersQuery(), ct);
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Suppliers.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeleteSupplierCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Supplier deleted successfully.");
        return RedirectToPage();
    }
}
