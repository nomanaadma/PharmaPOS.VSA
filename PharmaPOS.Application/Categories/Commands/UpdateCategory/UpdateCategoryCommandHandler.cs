using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.CategoryAggregate;

namespace PharmaPOS.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(
	ICategoryRepository categoryRepo,
	IUnitOfWork unitOfWork,
	ILogger<UpdateCategoryCommandHandler> logger) : IRequestHandler<UpdateCategoryCommand, ErrorOr<Updated>>
{
	public async Task<ErrorOr<Updated>> Handle(UpdateCategoryCommand command, CancellationToken ct)
	{
		var request = command.Request;

		var category = await categoryRepo.GetByIdAsync(command.Id, ct);
		if (category == null)
			return CommonErrors<Category>.NotFound(command.Id);

		if (await categoryRepo.ExistsByNameAsync(request.Name, command.Id, ct))
			return CategoryApplicationErrors.NameNotUnique;

		var updateResult = category.Update(request.Name);
		if (updateResult.IsError)
			return updateResult.Errors;

		categoryRepo.Update(category);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Category {CategoryId} updated", command.Id);
		return Result.Updated;
	}
}

