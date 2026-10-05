using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Suppliers.Queries.GetSupplier;

[AuthorizeCommand(Permissions = Permissions.Suppliers.Edit)]
public record GetSupplierQuery(int Id) : IRequest<ErrorOr<SupplierResponse>>;
