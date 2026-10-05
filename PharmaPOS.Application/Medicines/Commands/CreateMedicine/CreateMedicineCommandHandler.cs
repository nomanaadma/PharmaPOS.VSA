using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.MedicineAggregate;

namespace PharmaPOS.Application.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandHandler(
	IMedicineRepository medicineRepo,
	IUnitOfWork unitOfWork,
	ILogger<CreateMedicineCommandHandler> logger) : IRequestHandler<CreateMedicineCommand, ErrorOr<Created>>
{
	public async Task<ErrorOr<Created>> Handle(CreateMedicineCommand command, CancellationToken ct)
	{
		var medicineFields = command.Request.Adapt<MedicineFields>();

		var medicineResult = Medicine.Create(medicineFields);
		if (medicineResult.IsError)
			return medicineResult.Errors;

		var medicine = medicineResult.Value;
		await medicineRepo.AddAsync(medicine, ct);
		await unitOfWork.SaveChangesAsync(ct);

		logger.LogInformation("Medicine {MedicineId} '{Name}' created", medicine.Id, medicine.Name);
		return Result.Created;
	}
}
