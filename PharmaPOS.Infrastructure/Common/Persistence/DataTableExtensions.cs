using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Infrastructure.Common.Persistence;

/// <summary>
/// Generic DataTables server-side processing helper for EF Core queries.
/// Handles global search, SearchBuilder criteria, sorting, and pagination
/// for any EF Core entity type, driven by a <see cref="DataTableColumnMap{T}"/>.
/// </summary>
public static class DataTableExtensions
{
	/// <summary>
	/// Applies search, SearchBuilder, sorting, and pagination to the given query.
	/// </summary>
	public static async Task<DataTableResponse<T>> ToDataTableAsync<T>(
		this IQueryable<T> query,
		DataTableRequest request,
		DataTableColumnMap<T> columns,
		CancellationToken ct = default
	) where T : class
	{
		// 1. Total count (before any filtering)
		var totalRecords = await query.CountAsync(ct);

		// 2. Global search
		if (!string.IsNullOrWhiteSpace(request.SearchValue) && columns.GlobalSearchFilter != null)
		{
			query = columns.GlobalSearchFilter(query, request.SearchValue);
		}

		// 3. SearchBuilder criteria
		foreach (var criteria in request.SearchBuilderCriteria)
		{
			if (!columns.Columns.TryGetValue(criteria.OrigData, out var column))
				continue;

			query = column.Type switch
			{
				ColumnType.String => ApplyStringCondition(query, column.StringSelector!, criteria),
				ColumnType.Decimal => ApplyDecimalCondition(query, column.DecimalSelector!, criteria),
				ColumnType.DateTime => ApplyDateTimeCondition(query, column.DateTimeSelector!, criteria),
				_ => query
			};
		}

		// 4. Filtered count
		var filteredRecords = await query.CountAsync(ct);

		// 5. Sorting
		query = ApplySorting(query, request, columns);

		// 6. Pagination
		query = query.Skip(request.Start);
		if (request.Length > 0)
		{
			query = query.Take(request.Length);
		}

		var data = await query.ToListAsync(ct);

		return new DataTableResponse<T>
		{
			TotalRecords = totalRecords,
			FilteredRecords = filteredRecords,
			Data = data
		};
	}

	// ─── String column conditions (ILike-based) ────────────────────────

	private static IQueryable<T> ApplyStringCondition<T>(
		IQueryable<T> query,
		Expression<Func<T, string?>> selector,
		SearchCriteria criteria
	) where T : class
	{
		var val = criteria.Value0 ?? "";

		return criteria.Condition switch
		{
			"=" => query.Where(BuildILikePredicate(selector, val)),
			"!=" => query.Where(BuildNotILikePredicate(selector, val)),
			"starts" => query.Where(BuildILikePredicate(selector, $"{val}%")),
			"!starts" => query.Where(BuildNotILikePredicate(selector, $"{val}%")),
			"contains" => query.Where(BuildILikePredicate(selector, $"%{val}%")),
			"!contains" => query.Where(BuildNotILikePredicate(selector, $"%{val}%")),
			"ends" => query.Where(BuildILikePredicate(selector, $"%{val}")),
			"!ends" => query.Where(BuildNotILikePredicate(selector, $"%{val}")),
			"null" => query.Where(BuildIsNullOrEmptyPredicate(selector)),
			"!null" => query.Where(BuildIsNotNullOrEmptyPredicate(selector)),
			_ => query
		};
	}

	// ─── Decimal column conditions ─────────────────────────────────────

	private static IQueryable<T> ApplyDecimalCondition<T>(
		IQueryable<T> query,
		Expression<Func<T, decimal>> selector,
		SearchCriteria criteria
	) where T : class
	{
		if (!decimal.TryParse(criteria.Value0, out var d0))
			return query;
		
		decimal.TryParse(criteria.Value1, out var d1);

		return criteria.Condition switch
		{
			"=" => query.Where(BuildCompare(selector, d0, ExpressionType.Equal)),
			"!=" => query.Where(BuildCompare(selector, d0, ExpressionType.NotEqual)),
			"<" => query.Where(BuildCompare(selector, d0, ExpressionType.LessThan)),
			"<=" => query.Where(BuildCompare(selector, d0, ExpressionType.LessThanOrEqual)),
			">" => query.Where(BuildCompare(selector, d0, ExpressionType.GreaterThan)),
			">=" => query.Where(BuildCompare(selector, d0, ExpressionType.GreaterThanOrEqual)),
			"between" => query
				.Where(BuildCompare(selector, d0, ExpressionType.GreaterThanOrEqual))
				.Where(BuildCompare(selector, d1, ExpressionType.LessThanOrEqual)),
			"!between" => query.Where(BuildNotBetween(selector, d0, d1)),
			_ => query
		};
	}

	// ─── DateTime column conditions ────────────────────────────────────

	private static IQueryable<T> ApplyDateTimeCondition<T>(
		IQueryable<T> query,
		Expression<Func<T, DateTime>> selector,
		SearchCriteria criteria
	) where T : class
	{
		if (!DateTime.TryParse(criteria.Value0, out var dt0))
			return query;

		var date = dt0.Date;
		var nextDay = date.AddDays(1);

		return criteria.Condition switch
		{
			"=" or "contains" => query
				.Where(BuildDateCompare(selector, date, ExpressionType.GreaterThanOrEqual))
				.Where(BuildDateCompare(selector, nextDay, ExpressionType.LessThan)),

			"!=" or "!contains" => query.Where(BuildDateNotEqual(selector, date, nextDay)),

			"<" => query.Where(BuildDateCompare(selector, date, ExpressionType.LessThan)),
			"<=" => query.Where(BuildDateCompare(selector, nextDay, ExpressionType.LessThan)),
			">" => query.Where(BuildDateCompare(selector, nextDay, ExpressionType.GreaterThanOrEqual)),
			">=" => query.Where(BuildDateCompare(selector, date, ExpressionType.GreaterThanOrEqual)),

			"between" when DateTime.TryParse(criteria.Value1, out var dt1) => query
				.Where(BuildDateCompare(selector, date, ExpressionType.GreaterThanOrEqual))
				.Where(BuildDateCompare(selector, dt1.Date.AddDays(1), ExpressionType.LessThan)),

			"!between" when DateTime.TryParse(criteria.Value1, out var dt1) =>
				query.Where(BuildDateNotEqual(selector, date, dt1.Date.AddDays(1))),

			_ => query
		};
	}

	// ─── Sorting ───────────────────────────────────────────────────────

	private static IQueryable<T> ApplySorting<T>(
		IQueryable<T> query,
		DataTableRequest request,
		DataTableColumnMap<T> columns
	) where T : class
	{
		if (!string.IsNullOrEmpty(request.SortColumnIndex) &&
		    columns.SortColumns.TryGetValue(request.SortColumnIndex, out var sortExpr))
		{
			return request.SortDirection == "desc"
				? query.OrderByDescending(sortExpr)
				: query.OrderBy(sortExpr);
		}

		return query.OrderByDescending(columns.DefaultSort);
	}

	// ═══════════════════════════════════════════════════════════════════
	// Expression tree builders — these generate the LINQ predicates that
	// EF Core translates to SQL.
	// ═══════════════════════════════════════════════════════════════════

	// ─── ILike helpers ─────────────────────────────────────────────────

	private static Expression<Func<T, bool>> BuildILikePredicate<T>(
		Expression<Func<T, string?>> selector, string pattern)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;
		var toLowerMethod = typeof(string).GetMethod(nameof(string.ToLower), Type.EmptyTypes)!;
		var lowerBody = Expression.Call(body, toLowerMethod);
		var patternExpr = Expression.Constant(pattern.ToLower());

		var likeMethod = typeof(DbFunctionsExtensions).GetMethod(
			nameof(DbFunctionsExtensions.Like),
			[typeof(DbFunctions), typeof(string), typeof(string)])!;

		var efFunctions = Expression.Property(null, typeof(EF), nameof(EF.Functions));
		var call = Expression.Call(likeMethod, efFunctions, lowerBody, patternExpr);

		return Expression.Lambda<Func<T, bool>>(call, param);
	}

	private static Expression<Func<T, bool>> BuildNotILikePredicate<T>(
		Expression<Func<T, string?>> selector, string pattern)
	{
		var iLike = BuildILikePredicate(selector, pattern);
		var param = iLike.Parameters[0];
		var negated = Expression.Not(iLike.Body);
		return Expression.Lambda<Func<T, bool>>(negated, param);
	}

	private static Expression<Func<T, bool>> BuildIsNullOrEmptyPredicate<T>(
		Expression<Func<T, string?>> selector)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;
		var nullConst = Expression.Constant(null, typeof(string));
		var emptyConst = Expression.Constant("", typeof(string));

		var isNull = Expression.Equal(body, nullConst);
		var isEmpty = Expression.Equal(body, emptyConst);
		var combined = Expression.OrElse(isNull, isEmpty);

		return Expression.Lambda<Func<T, bool>>(combined, param);
	}

	private static Expression<Func<T, bool>> BuildIsNotNullOrEmptyPredicate<T>(
		Expression<Func<T, string?>> selector)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;
		var nullConst = Expression.Constant(null, typeof(string));
		var emptyConst = Expression.Constant("", typeof(string));

		var isNotNull = Expression.NotEqual(body, nullConst);
		var isNotEmpty = Expression.NotEqual(body, emptyConst);
		var combined = Expression.AndAlso(isNotNull, isNotEmpty);

		return Expression.Lambda<Func<T, bool>>(combined, param);
	}

	// ─── Decimal comparison helpers ────────────────────────────────────

	private static Expression<Func<T, bool>> BuildCompare<T>(
		Expression<Func<T, decimal>> selector, decimal value, ExpressionType comparison)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;
		var constant = Expression.Constant(value);
		var compare = Expression.MakeBinary(comparison, body, constant);
		return Expression.Lambda<Func<T, bool>>(compare, param);
	}

	private static Expression<Func<T, bool>> BuildNotBetween<T>(
		Expression<Func<T, decimal>> selector, decimal low, decimal high)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;

		var ltLow = Expression.LessThan(body, Expression.Constant(low));
		var gtHigh = Expression.GreaterThan(body, Expression.Constant(high));
		var combined = Expression.OrElse(ltLow, gtHigh);

		return Expression.Lambda<Func<T, bool>>(combined, param);
	}

	// ─── DateTime comparison helpers ───────────────────────────────────

	private static Expression<Func<T, bool>> BuildDateCompare<T>(
		Expression<Func<T, DateTime>> selector, DateTime value, ExpressionType comparison)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;
		var constant = Expression.Constant(value);
		var compare = Expression.MakeBinary(comparison, body, constant);
		return Expression.Lambda<Func<T, bool>>(compare, param);
	}

	private static Expression<Func<T, bool>> BuildDateNotEqual<T>(
		Expression<Func<T, DateTime>> selector, DateTime date, DateTime nextDay)
	{
		var param = selector.Parameters[0];
		var body = selector.Body;

		var ltDate = Expression.LessThan(body, Expression.Constant(date));
		var geNextDay = Expression.GreaterThanOrEqual(body, Expression.Constant(nextDay));
		var combined = Expression.OrElse(ltDate, geNextDay);

		return Expression.Lambda<Func<T, bool>>(combined, param);
	}
}
