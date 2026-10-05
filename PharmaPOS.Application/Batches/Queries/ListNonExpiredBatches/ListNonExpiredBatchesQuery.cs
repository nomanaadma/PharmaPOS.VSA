using MediatR;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Batches.Queries.ListNonExpiredBatches;

public record ListNonExpiredBatchesQuery(int MedicineId) : IRequest<List<Batch>>;
