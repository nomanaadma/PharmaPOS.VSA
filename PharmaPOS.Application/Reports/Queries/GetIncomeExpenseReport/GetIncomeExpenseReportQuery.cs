using MediatR;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Application.Common.Authorization;

namespace PharmaPOS.Application.Reports.Queries.GetIncomeExpenseReport;

[AuthorizeCommand(Permissions = Permissions.Reports.View)]
public record GetIncomeExpenseReportQuery(InventoryReportRequest Request) : IRequest<StatsReportResponse>;
