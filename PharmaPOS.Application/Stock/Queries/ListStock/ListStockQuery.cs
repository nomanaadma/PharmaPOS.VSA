using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Stock.Queries.ListStock;

[AuthorizeCommand(Permissions = Permissions.Stock.View)]
public record ListStockQuery(string? Type) : IRequest<List<BatchResponse>>;
