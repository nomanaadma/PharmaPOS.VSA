using MediatR;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Reports.Queries.ListInventoryReport;

[AuthorizeCommand(Permissions = Permissions.Reports.View)]
public record ListInventoryReportQuery : IRequest<List<InventoryReportResponse>>;
