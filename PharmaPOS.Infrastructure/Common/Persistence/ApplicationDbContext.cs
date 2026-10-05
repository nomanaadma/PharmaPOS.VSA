using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaPOS.Domain.BatchAggregate;
using PharmaPOS.Domain.BillingAggregate;
using PharmaPOS.Domain.CategoryAggregate;
using PharmaPOS.Domain.CustomerAggregate;
using PharmaPOS.Domain.MediaAggregate;
using PharmaPOS.Domain.MedicineAggregate;
using PharmaPOS.Domain.PaymentMethodAggregate;
using PharmaPOS.Domain.PurchaseAggregate;
using PharmaPOS.Domain.SettingAggregate;
using PharmaPOS.Domain.SupplierAggregate;
using PharmaPOS.Domain.Common;

namespace PharmaPOS.Infrastructure.Common.Persistence;

public class ApplicationDbContext(
	DbContextOptions<ApplicationDbContext> options
	) : IdentityDbContext(options)
{
	public DbSet<Setting> Settings { get; set; } = null!;
	public DbSet<Media> Media { get; set; } = null!;
	public DbSet<Supplier> Suppliers { get; set; } = null!;
	public DbSet<Category> Categories { get; set; } = null!;
	public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
	public DbSet<Customer> Customers { get; set; } = null!;
	public DbSet<Medicine> Medicines { get; set; } = null!;
	public DbSet<Purchase> Purchases { get; set; } = null!;
	public DbSet<Batch> Batches { get; set; } = null!;
	public DbSet<Bill> Bills { get; set; } = null!;
	public DbSet<BillItem> BillItems { get; set; } = null!;
	public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
	
}
