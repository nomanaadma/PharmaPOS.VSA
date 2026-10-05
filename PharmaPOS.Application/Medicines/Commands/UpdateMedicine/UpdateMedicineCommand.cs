using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Commands.UpdateMedicine;

[AuthorizeCommand(Permissions = Permissions.Medicine.Edit)]
public record UpdateMedicineCommand(int Id, MedicineRequest Request) : IRequest<ErrorOr<Updated>>;
