using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Suppliers.Queries.ListSuppliers;

[AuthorizeCommand(Permissions = Permissions.Suppliers.List)]
public record ListSuppliersQuery : IRequest<List<SupplierResponse>>;
