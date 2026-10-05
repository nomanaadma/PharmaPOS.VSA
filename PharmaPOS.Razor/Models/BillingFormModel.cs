using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PharmaPOS.Razor.Models;

public class BillingFormModel : OrderDetailsModel<BillingItemFormModel>
{
	public int? CustomerId { get; init; }

	[Required(ErrorMessage = "Name is required.")]
	public string Name { get; init; } = null!;

	[EmailAddress(ErrorMessage = "Invalid Email Address")]
	public string? Email { get; init; }

	public string? Mobile { get; init; }

	[Required(ErrorMessage = "Payment Method is required.")]
	public int Method { get; init; }

	public IEnumerable<SelectListItem> PaymentMethods { get; set; } = [];
}

public class BillingItemFormModel : PricingDetailModel
{
	public int Batch { get; init; }
	public string BatchName { get; init; } = null!;
	public List<BillingItemBatchesFormModel> Batches { get; init; } = [];
}

public class BillingItemBatchesFormModel : Model
{
	
	public decimal Qty { get; init; }

	public decimal Sold { get; init; }
	
	public string Batch { get; init; } = null!;
	
}
