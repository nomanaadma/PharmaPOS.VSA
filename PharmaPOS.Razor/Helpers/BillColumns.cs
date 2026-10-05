using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Helpers;

/// <summary>
/// Column configuration for Bill entity DataTables filtering.
/// Maps DataTables origData names to Bill entity expressions.
/// </summary>
public static class BillColumns
{
	public static DataTableColumnMap<BillingListResponse> GetColumnMap() => new()
	{
		GlobalSearchFilter = (query, search) =>
		{
			
			return query.Where(mb =>
				
				EF.Functions.ILike(mb.Name, $"%{search}%") ||
				(mb.Note != null &&
				 EF.Functions.ILike(mb.Note, $"%{search}%")) ||
				EF.Functions.ILike(mb.SubTotal.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mb.Tax.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mb.Discount.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mb.Amount.ToString(), $"%{search}%")
			);
			
		},

		Columns = new Dictionary<string, DataTableColumn<BillingListResponse>>
		{
			["name"] = new()
			{
				Type = ColumnType.String,
				StringSelector = mb => mb.Name
			},
			["subtotal"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mb => mb.SubTotal
			},
			["tax"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mb => mb.Tax
			},
			["discount"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mb => mb.Discount
			},
			["amount"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mb => mb.Amount
			},
			["date"] = new()
			{
				Type = ColumnType.DateTime,
				DateTimeSelector = mb => mb.Date
			}
		},

		SortColumns = new Dictionary<string, Expression<Func<BillingListResponse, object>>>
		{
			["1"] = mb => mb.Name,
			["2"] = mb => mb.SubTotal,
			["3"] = mb => mb.Tax,
			["4"] = mb => mb.Discount,
			["5"] = mb => mb.Amount,
			["6"] = mb => mb.Date
		},

		DefaultSort = mb => mb.Id
	};
}
