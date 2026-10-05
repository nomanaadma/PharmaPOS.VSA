using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Suppliers.Commands.CreateSupplier;

[AuthorizeCommand(Permissions = Permissions.Suppliers.Add)]
public record CreateSupplierCommand(SupplierRequest Request) : IRequest<ErrorOr<Created>>;
