using ErrorOr;
using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Suppliers.Commands.UpdateSupplier;

[AuthorizeCommand(Permissions = Permissions.Suppliers.Edit)]
public record UpdateSupplierCommand(int Id, SupplierRequest Request) : IRequest<ErrorOr<Updated>>;
