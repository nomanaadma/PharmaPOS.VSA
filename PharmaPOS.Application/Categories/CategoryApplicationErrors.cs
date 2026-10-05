using ErrorOr;

namespace PharmaPOS.Application.Categories;


public static class CategoryApplicationErrors
{

	public static readonly Error NameNotUnique =
		Error.Conflict("Category.NameNotUnique", "Category Name must be unique.");
}
