using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Categories.Queries.ListCategoriesLookup;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Medicines.Commands.UpdateMedicine;
using PharmaPOS.Application.Medicines.Queries.GetMedicine;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Medicines;

[Authorize(Policy = Permissions.Medicine.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public MedicineViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetMedicineQuery(id), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);
        
        var categories = (await sender.Send(new ListCategoriesLookupQuery(), ct)).ToSelectList();
        
        Input = result.Value.Adapt<MedicineViewModel>();
        Input.Categories = categories;
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken ct)
    {
        Input.Categories = (await sender.Send(new ListCategoriesLookupQuery(), ct)).ToSelectList();
            
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        if (Input.Id == 0)
        {
            NotifyError("Medicine ID is required for editing.");
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<MedicineRequest>();

        var result = await sender.Send(new UpdateMedicineCommand(id, request), ct);

        if (result.IsError)
        {
            return HandleErrors(result.Errors);
        }

        NotifySuccess("Medicine updated successfully.");
        return RedirectToPage("/Medicines/Index");
    }
}
