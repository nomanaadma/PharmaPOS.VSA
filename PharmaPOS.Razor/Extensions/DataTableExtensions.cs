using PharmaPOS.Contracts.Requests;

namespace PharmaPOS.Razor.Extensions;

public static class DataTableExtensions
{
	
	/// <summary>
	/// Parses a DataTables server-side POST into a strongly-typed request object.
	/// </summary>
	public static DataTableRequest ToDataTableRequest(this IFormCollection form)
	{
		var request = new DataTableRequest
		{
			Draw = Convert.ToInt32(form["draw"].FirstOrDefault() ?? "1"),
			Start = Convert.ToInt32(form["start"].FirstOrDefault() ?? "0"),
			Length = Convert.ToInt32(form["length"].FirstOrDefault() ?? "10"),
			SearchValue = form["search[value]"].FirstOrDefault(),
			SortColumnIndex = form["order[0][column]"].FirstOrDefault(),
			SortDirection = form["order[0][dir]"].FirstOrDefault() ?? "asc"
		};

		// Parse SearchBuilder criteria
		var sbIndex = 0;
		while (form.ContainsKey($"searchBuilder[criteria][{sbIndex}][condition]"))
		{
			var origData = form[$"searchBuilder[criteria][{sbIndex}][origData]"].FirstOrDefault();
			var condition = form[$"searchBuilder[criteria][{sbIndex}][condition]"].FirstOrDefault();

			if (!string.IsNullOrEmpty(origData) && !string.IsNullOrEmpty(condition))
			{
				request.SearchBuilderCriteria.Add(new SearchCriteria
				{
					OrigData = origData,
					Condition = condition,
					Type = form[$"searchBuilder[criteria][{sbIndex}][type]"].FirstOrDefault() ?? "",
					Value0 = form[$"searchBuilder[criteria][{sbIndex}][value1]"].FirstOrDefault(),
					Value1 = form[$"searchBuilder[criteria][{sbIndex}][value2]"].FirstOrDefault()
				});
			}

			sbIndex++;
		}

		return request;
	}
}