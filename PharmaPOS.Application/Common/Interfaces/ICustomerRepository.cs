using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.CustomerAggregate;

namespace PharmaPOS.Application.Common.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
	Task<bool> ExistsByEmailAsync(string email, int? excludeId = null, CancellationToken ct = default);
	Task<List<CustomerSearchResult>> SearchCustomersAsync(string term, int take = 7, CancellationToken ct = default);
	Task<Customer?> FindByEmailOrPhoneAsync(string? email, string? phone, CancellationToken ct = default);
}
