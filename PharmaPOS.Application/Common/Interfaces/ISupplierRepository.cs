using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.SupplierAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
	Task<bool> ExistsByEmailAsync(string email, int? excludeId = null, CancellationToken ct = default);
	Task<List<LookupItem>> GetLookupListAsync(CancellationToken ct = default);
}
