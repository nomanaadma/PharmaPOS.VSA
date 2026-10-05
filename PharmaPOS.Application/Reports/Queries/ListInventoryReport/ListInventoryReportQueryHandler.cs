using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Reports.Queries.ListInventoryReport;

public class ListInventoryReportQueryHandler(
	IReportRepository reportRepo) : IRequestHandler<ListInventoryReportQuery, List<InventoryReportResponse>>
{
	public async Task<List<InventoryReportResponse>> Handle(ListInventoryReportQuery query, CancellationToken ct)
	{
		return await reportRepo.GetInventoryReportAsync(ct);
	}
}
