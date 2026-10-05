using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Categories.Commands.DeleteCategory;
using PharmaPOS.Application.Categories.Queries.ListCategories;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Pages.Categories;

[Authorize(Policy = Permissions.Category.List)]
public class IndexModel(ISender sender) : BasePageModel
{
    public IEnumerable<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        var categories = await sender.Send(new ListCategoriesQuery(), ct);
        Categories = categories;
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken ct)
    {
        var hasPermission = User.HasClaim("Permission", Permissions.Category.Delete);
        if (!hasPermission)
            return Forbid();

        var result = await sender.Send(new DeleteCategoryCommand(id), ct);
        if (result.IsError)
            return HandleErrors(result.Errors, redirectOnError: true);

        NotifySuccess("Category deleted successfully.");
        return RedirectToPage();
    }
}
