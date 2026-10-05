using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.CategoryAggregate;

namespace PharmaPOS.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(
	ICategoryRepository categoryRepo,
	IUnitOfWork unitOfWork,
	ILogger<DeleteCategoryCommandHandler> logger) : IRequestHandler<DeleteCategoryCommand, ErrorOr<Deleted>>
{
	public async Task<ErrorOr<Deleted>> Handle(DeleteCategoryCommand command, CancellationToken ct)
	{
		var category = await categoryRepo.GetByIdAsync(command.Id, ct);
		if (category == null)
			return CommonErrors<Category>.NotFound(command.Id);

		categoryRepo.Remove(category);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Category {CategoryId} deleted", command.Id);
		return Result.Deleted;
	}
}

