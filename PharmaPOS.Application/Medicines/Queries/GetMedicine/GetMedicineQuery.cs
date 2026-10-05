using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Queries.GetMedicine;

[AuthorizeCommand(Permissions = Permissions.Medicine.View)]
public record GetMedicineQuery(int Id) : IRequest<ErrorOr<MedicineResponse>>;
