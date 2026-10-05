using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Stock.Commands.UpdateStock;

[AuthorizeCommand(Permissions = Permissions.Stock.View)]
public record UpdateStockCommand(int Id, int MedicineId, decimal Available) : IRequest<ErrorOr<Updated>>;
