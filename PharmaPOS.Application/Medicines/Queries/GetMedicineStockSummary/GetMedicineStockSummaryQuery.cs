using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Medicines.Queries.GetMedicineStockSummary;

[AuthorizeCommand(Permissions = Permissions.Medicine.View)]
public record GetMedicineStockSummaryQuery(int MedicineId) : IRequest<(IEnumerable<BatchResponse> liveBatches, IEnumerable<BatchResponse> badBatches)>;
