using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.CategoryAggregate;

namespace PharmaPOS.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(
	ICategoryRepository categoryRepo,
	IUnitOfWork unitOfWork,
	ILogger<CreateCategoryCommandHandler> logger) : IRequestHandler<CreateCategoryCommand, ErrorOr<Created>>
{
	public async Task<ErrorOr<Created>> Handle(CreateCategoryCommand command, CancellationToken ct)
	{
		var request = command.Request;

		if (await categoryRepo.ExistsByNameAsync(request.Name, null, ct))
			return CategoryApplicationErrors.NameNotUnique;

		var categoryResult = Category.Create(request.Name);
		if (categoryResult.IsError)
			return categoryResult.Errors;

		var category = categoryResult.Value;
		await categoryRepo.AddAsync(category, ct);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Category {CategoryId} '{Name}' created", category.Id, category.Name);
		return Result.Created;
	}
}
