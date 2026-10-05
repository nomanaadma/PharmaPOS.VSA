using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Categories.Queries.ListCategoriesLookup;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Medicines.Commands.CreateMedicine;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Medicines;

[Authorize(Policy = Permissions.Medicine.Add)]
public class AddModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public MedicineViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Input.Categories = (await sender.Send(new ListCategoriesLookupQuery(), ct)).ToSelectList();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Input.Categories = (await sender.Send(new ListCategoriesLookupQuery(), ct)).ToSelectList();
        
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<MedicineRequest>();

        var result = await sender.Send(new CreateMedicineCommand(request), ct);

        if (result.IsError)
        {
            return HandleErrors(result.Errors);
        }

        NotifySuccess("Medicine created successfully.");
        return RedirectToPage("/Medicines/Index");
    }
}
