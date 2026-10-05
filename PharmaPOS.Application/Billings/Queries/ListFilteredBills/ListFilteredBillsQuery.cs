using MediatR;
using PharmaPOS.Application.Common.Helpers;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Contracts.Responses;

namespace PharmaPOS.Application.Billings.Queries.ListFilteredBills;

public record ListFilteredBillsQuery(
	DataTableRequest Request, 
	DataTableColumnMap<BillingListResponse> Columns) : IRequest<DataTableResponse<BillingListResponse>>;
