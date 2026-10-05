using ErrorOr;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Domain.CategoryAggregate;

public class Category : AggregateRoot
{
	// EF Core parameterless constructor
	private Category() { }

	private Category(string name)
	{
		Name = name;
	}

	public string Name { get; private set; } = null!;

	public static ErrorOr<Category> Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			return CategoryErrors.NameRequired;

		return new Category(name);
	}

	public ErrorOr<Updated> Update(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			return CategoryErrors.NameRequired;

		Name = name;
		return Result.Updated;
	}
	
}
