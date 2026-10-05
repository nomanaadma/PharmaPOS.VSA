using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Reports.Queries.GetIncomeExpenseReport;

public class GetIncomeExpenseReportQueryHandler(
	IReportRepository reportRepo) : IRequestHandler<GetIncomeExpenseReportQuery, StatsReportResponse>
{
	public async Task<StatsReportResponse> Handle(GetIncomeExpenseReportQuery query, CancellationToken ct)
	{
		return await reportRepo.GetIncomeExpenseReportAsync(query.Request, ct);
	}
}
