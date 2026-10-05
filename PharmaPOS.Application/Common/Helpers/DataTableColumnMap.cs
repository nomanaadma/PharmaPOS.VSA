using System.Linq.Expressions;

namespace PharmaPOS.Application.Common.Helpers;

/// <summary>
/// Defines the type of searchable/sortable DataTable column.
/// </summary>
public enum ColumnType
{
	String,
	Decimal,
	DateTime
}

/// <summary>
/// Configuration for a single DataTable column that supports SearchBuilder filtering.
/// Exactly one of the typed selectors should be set, matching the <see cref="Type"/>.
/// </summary>
public class DataTableColumn<T> where T : class
{
	public required ColumnType Type { get; init; }
	public Expression<Func<T, string?>>? StringSelector { get; init; }
	public Expression<Func<T, decimal>>? DecimalSelector { get; init; }
	public Expression<Func<T, DateTime>>? DateTimeSelector { get; init; }
}

/// <summary>
/// Maps DataTables origData names and column indexes to entity expressions.
/// Each entity type (Purchase, Bill, etc.) provides its own column map instance.
/// This is the C# equivalent of the PHP Search model's column configuration.
/// </summary>
public class DataTableColumnMap<T> where T : class
{
	/// <summary>
	/// Applied when the user types in the global search box.
	/// Receives the current query and the search string, returns a filtered query.
	/// </summary>
	public Func<IQueryable<T>, string, IQueryable<T>>? GlobalSearchFilter { get; init; }

	/// <summary>
	/// SearchBuilder columns keyed by origData name (e.g. "name", "total", "date").
	/// </summary>
	public Dictionary<string, DataTableColumn<T>> Columns { get; init; } = new();

	/// <summary>
	/// Sort expressions keyed by DataTables column index string (e.g. "1", "2", "3").
	/// </summary>
	public Dictionary<string, Expression<Func<T, object>>> SortColumns { get; init; } = new();

	/// <summary>
	/// Fallback sort expression when no order column is specified by the client.
	/// </summary>
	public required Expression<Func<T, object>> DefaultSort { get; init; }
}
