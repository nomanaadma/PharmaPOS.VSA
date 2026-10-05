using MediatR;
using PharmaPOS.Domain.BatchAggregate;

namespace PharmaPOS.Application.Batches.Queries.GetBatch;

public record GetBatchQuery(int MedicineId, int BatchId) : IRequest<Batch?>;
