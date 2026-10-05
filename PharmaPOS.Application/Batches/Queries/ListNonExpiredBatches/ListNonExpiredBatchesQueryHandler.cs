using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Batches.Queries.ListNonExpiredBatches;

public class ListNonExpiredBatchesQueryHandler(
	IBatchRepository batchRepo) : IRequestHandler<ListNonExpiredBatchesQuery, List<Batch>>
{
	public async Task<List<Batch>> Handle(ListNonExpiredBatchesQuery query, CancellationToken ct)
	{
		return await batchRepo.GetNonExpiredBatchesAsync(query.MedicineId, ct);
	}
}
