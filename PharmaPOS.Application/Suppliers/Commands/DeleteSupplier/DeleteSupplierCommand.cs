using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Suppliers.Commands.DeleteSupplier;

[AuthorizeCommand(Permissions = Permissions.Suppliers.Delete)]
public record DeleteSupplierCommand(int Id) : IRequest<ErrorOr<Deleted>>;
