namespace PharmaPOS.Contracts.Requests;

/// <summary>
/// Represents a single SearchBuilder criterion parsed from the DataTables form POST.
/// </summary>
public class SearchCriteria
{
	public string OrigData { get; init; } = "";
	public string Condition { get; init; } = "";
	public string Type { get; set; } = "";
	public string? Value0 { get; init; }
	public string? Value1 { get; init; }
}

/// <summary>
/// Encapsulates all DataTables server-side parameters extracted from Request.Form.
/// Replaces the duplicated parameter-parsing code at the top of every Filter action.
/// </summary>
public class DataTableRequest
{
	public int Draw { get; init; }
	public int Start { get; init; }
	public int Length { get; init; }
	public string? SearchValue { get; init; }
	public string? SortColumnIndex { get; init; }
	public string SortDirection { get; init; } = "asc";
	public List<SearchCriteria> SearchBuilderCriteria { get; set; } = [];
	
}
