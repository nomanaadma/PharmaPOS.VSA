using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Categories.Commands.UpdateCategory;
using PharmaPOS.Application.Categories.Queries.GetCategory;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;
using PharmaPOS.Razor.Mappers;

namespace PharmaPOS.Razor.Pages.Categories;

[Authorize(Policy = Permissions.Category.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public CategoryViewModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetCategoryQuery(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors);

        Input = result.Value.Adapt<CategoryViewModel>();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken ct)
    {
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        if (Input.Id == 0)
        {
            NotifyError("Category ID is required for editing.");
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<CategoryRequest>();

        var result = await sender.Send(new UpdateCategoryCommand(id, request), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, new() { ["Category.NameNotUnique"] = "Input.Name" });

        NotifySuccess("Category updated successfully.");
        return RedirectToPage("/Categories/Index");
    }
}
