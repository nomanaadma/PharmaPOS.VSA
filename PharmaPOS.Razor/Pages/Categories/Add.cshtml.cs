using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Categories.Commands.CreateCategory;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Categories;

[Authorize(Policy = Permissions.Category.Add)]
public class AddModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public CategoryViewModel Input { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var request = Input.Adapt<CategoryRequest>();

        var result = await sender.Send(new CreateCategoryCommand(request), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, new() { ["Category.NameNotUnique"] = "Input.Name" });

        NotifySuccess("Category created successfully.");
        return RedirectToPage("/Categories/Index");
    }
}
