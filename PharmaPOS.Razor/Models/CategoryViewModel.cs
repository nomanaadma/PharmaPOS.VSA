using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Razor.Models;

public class CategoryViewModel : Model
{

	[Required(ErrorMessage = "Category Name is required.")]
	[StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
	public string Name { get; init; } = null!;
}
