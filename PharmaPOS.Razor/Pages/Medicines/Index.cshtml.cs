using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Medicines.Commands.DeleteMedicine;
using PharmaPOS.Application.Medicines.Queries.ListMedicinesWithStock;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Medicines;

[Authorize(Policy = Permissions.Medicine.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public IEnumerable<MedicineResponse> Medicines { get; set; } = new List<MedicineResponse>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Medicines = await sender.Send(new ListMedicinesWithStockQuery(), ct);
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Medicine.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeleteMedicineCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Medicine deleted successfully.");
        return RedirectToPage();
    }
}
