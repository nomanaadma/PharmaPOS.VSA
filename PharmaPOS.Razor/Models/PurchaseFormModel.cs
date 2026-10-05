using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PharmaPOS.Razor.Models;

public class PurchaseFormModel : OrderDetailsModel<PurchaseItemFormModel>
{

	[Required(ErrorMessage = "Supplier is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "Please select a valid supplier.")]
	public int Supplier { get; init; }
	
	public IEnumerable<SelectListItem> Suppliers { get; set; } = [];
}

public class PurchaseItemFormModel : PricingDetailModel
{
	public string Batch { get; init; } = null!;
	public string? Pqty { get; init; }
	public decimal Purchaseprice { get; init; }
}
