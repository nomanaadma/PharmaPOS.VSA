using MediatR;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Categories.Queries.ListCategoriesLookup;

public record ListCategoriesLookupQuery : IRequest<IEnumerable<LookupItem>>;
