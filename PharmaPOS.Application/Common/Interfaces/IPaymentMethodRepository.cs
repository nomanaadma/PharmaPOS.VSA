using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.PaymentMethodAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface IPaymentMethodRepository : IRepository<PaymentMethod>
{
	Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default);
	Task<List<LookupItem>> GetActiveLookupListAsync(CancellationToken ct = default);

	Task<string> GetMethodNameByIdAsync(int id, CancellationToken ct = default);
}
