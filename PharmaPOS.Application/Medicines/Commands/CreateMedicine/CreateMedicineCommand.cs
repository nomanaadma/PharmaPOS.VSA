using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Commands.CreateMedicine;

[AuthorizeCommand(Permissions = Permissions.Medicine.Add)]
public record CreateMedicineCommand(MedicineRequest Request) : IRequest<ErrorOr<Created>>;
