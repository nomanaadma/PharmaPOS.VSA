using MediatR;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Suppliers.Queries.ListSuppliersLookup;

public record ListSuppliersLookupQuery : IRequest<IEnumerable<LookupItem>>;
