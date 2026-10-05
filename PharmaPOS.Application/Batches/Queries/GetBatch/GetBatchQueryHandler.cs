using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Batches.Queries.GetBatch;

public class GetBatchQueryHandler(
	IBatchRepository batchRepo) : IRequestHandler<GetBatchQuery, Batch?>
{
	public async Task<Batch?> Handle(GetBatchQuery query, CancellationToken ct)
	{
		return await batchRepo.GetBatchAsync(query.MedicineId, query.BatchId, ct);
	}
}
