using Microsoft.AspNetCore.Mvc.Rendering;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Extensions;

public static class LookupExtensions
{
	public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<LookupItem> items)
	{
		return items.Select(i => new SelectListItem
		{
			Value = i.Value,
			Text = i.Text
		});
	}
}
