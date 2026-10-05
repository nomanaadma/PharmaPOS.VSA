using ErrorOr;

namespace PharmaPOS.Domain.CategoryAggregate;

public static class CategoryErrors
{
	public static Error NameRequired =>
		Error.Validation("Category.NameRequired", "Category Name is required.");
}