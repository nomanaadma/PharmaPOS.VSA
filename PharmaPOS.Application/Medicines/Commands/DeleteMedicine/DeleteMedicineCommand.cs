using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Commands.DeleteMedicine;

[AuthorizeCommand(Permissions = Permissions.Medicine.Delete)]
public record DeleteMedicineCommand(int Id) : IRequest<ErrorOr<Deleted>>;
