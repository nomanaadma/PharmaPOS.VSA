using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Razor.Helpers;

/// <summary>
/// Column configuration for Purchase entity DataTables filtering.
/// Maps DataTables origData names to PurchaseListDto expressions.
/// </summary>
public static class PurchaseColumns
{
	public static DataTableColumnMap<PurchaseListResponse> GetColumnMap() => new()
	{
		GlobalSearchFilter = (query, search) =>
		{
			
			return query.Where(mp =>
				EF.Functions.ILike(mp.SupplierName, $"%{search}%") ||
    
				(mp.Note != null &&
				 EF.Functions.ILike(mp.Note, $"%{search}%")) ||

				EF.Functions.ILike(mp.SubTotal.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mp.Tax.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mp.Discount.ToString(), $"%{search}%") ||
				EF.Functions.ILike(mp.Amount.ToString(), $"%{search}%")
			);
			
		},

		Columns = new Dictionary<string, DataTableColumn<PurchaseListResponse>>
		{
			["name"] = new()
			{
				Type = ColumnType.String,
				StringSelector = mp => mp.SupplierName
			},
			["total"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mp => mp.SubTotal
			},
			["tax"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mp => mp.Tax
			},
			["discount"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mp => mp.Discount
			},
			["amount"] = new()
			{
				Type = ColumnType.Decimal,
				DecimalSelector = mp => mp.Amount
			},
			["date"] = new()
			{
				Type = ColumnType.DateTime,
				DateTimeSelector = mp => mp.Date
			}
		},

		SortColumns = new Dictionary<string, Expression<Func<PurchaseListResponse, object>>>
		{
			["1"] = mp => mp.SupplierName,
			["2"] = mp => mp.SubTotal,
			["3"] = mp => mp.Tax,
			["4"] = mp => mp.Discount,
			["5"] = mp => mp.Amount,
			["6"] = mp => mp.Date
		},

		DefaultSort = mp => mp.Id
	};
}
