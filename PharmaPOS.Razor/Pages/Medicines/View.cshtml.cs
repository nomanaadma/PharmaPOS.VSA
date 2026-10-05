using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Medicines.Queries.GetMedicine;
using PharmaPOS.Application.Medicines.Queries.GetMedicineStockSummary;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Medicines;

[Authorize(Policy = Permissions.Medicine.View)]
public class ViewModel(ISender sender) : BasePageModel
{
    public MedicineResponse Medicine { get; set; } = null!;
    public IEnumerable<BatchResponse> LiveStock { get; set; } = new List<BatchResponse>();
    public IEnumerable<BatchResponse> BadStock { get; set; } = new List<BatchResponse>();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetMedicineQuery(id), ct);

        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);
        
        var stockSummary = await sender.Send(new GetMedicineStockSummaryQuery(id), ct);

        Medicine = result.Value;
        LiveStock = stockSummary.liveBatches;
        BadStock = stockSummary.badBatches;
        
        return Page();
    }
}
