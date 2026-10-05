using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Stock.Commands.DeleteStock;

[AuthorizeCommand(Permissions = Permissions.Stock.Delete)]
public record DeleteStockCommand(int Id) : IRequest<ErrorOr<Deleted>>;
