using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PharmaPOS.Razor.Models;

public class MedicineViewModel : Model
{

	[Required(ErrorMessage = "Medicine Name is required.")]
	[StringLength(255, ErrorMessage = "Medicine Name cannot exceed 255 characters.")]
	public string Name { get; init; } = null!;

	[Required(ErrorMessage = "Medicine Company is required.")]
	[StringLength(255, ErrorMessage = "Medicine Company cannot exceed 255 characters.")]
	public string Company { get; init; } = null!;

	[Required(ErrorMessage = "Medicine Generic is required.")]
	public string Generic { get; init; } = null!;

	[StringLength(255, ErrorMessage = "Medicine Group cannot exceed 255 characters.")]
	public string? MedicineGroup { get; init; }

	[Required(ErrorMessage = "Medicine Category is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "Please select a valid category.")]
	public int CategoryId { get; init; }

	public string? CategoryName { get; init; }

	[StringLength(255, ErrorMessage = "Store Box cannot exceed 255 characters.")]
	public string? StoreBox { get; init; }

	[Range(0, double.MaxValue, ErrorMessage = "Min Level must be a non-negative number.")]
	public decimal? MinLevel { get; init; }

	[Range(0, double.MaxValue, ErrorMessage = "Re-Order Level must be a non-negative number.")]
	public decimal? ReOrderLevel { get; init; }

	[Required(ErrorMessage = "Unit is required.")]
	[StringLength(255, ErrorMessage = "Unit cannot exceed 255 characters.")]
	public string Unit { get; init; } = null!;

	[StringLength(255, ErrorMessage = "Unit/Packing cannot exceed 255 characters.")]
	public string? UnitPacking { get; init; }

	public string? Note { get; init; }

	public decimal LiveStock { get; set; }

	public DateTime? CreatedDate { get; init; }

	public IEnumerable<SelectListItem> Categories { get; set; } = [];

}
