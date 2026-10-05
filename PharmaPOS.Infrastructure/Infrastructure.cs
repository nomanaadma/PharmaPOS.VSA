using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Infrastructure.Common.BackgroundJobs;
using PharmaPOS.Infrastructure.Common.Persistence;

namespace PharmaPOS.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
	{
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
		}

		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseNpgsql(connectionString, b => 
				b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
			options.EnableSensitiveDataLogging();
		});

		services.AddScoped<DbInitializer>();
		
		var assembly = Assembly.GetExecutingAssembly();

		// 1. Find all concrete classes that implement IRepository<T>
		var repositoryTypes = assembly.GetTypes()
			.Where(t => t is { IsClass: true, IsAbstract: false })
			.Where(t => t.GetInterfaces().Any(i => 
				i.IsGenericType && 
				i.GetGenericTypeDefinition() == typeof(IRepository<>)));

		foreach (var type in repositoryTypes)
		{
			// 2. Get the specific interface (e.g., ICategoryRepository) 
			// by ignoring the generic base IRepository<T>
			var targetInterface = type.GetInterfaces()
				.FirstOrDefault(i => !i.IsGenericType);

			if (targetInterface != null)
			{
				services.AddScoped(targetInterface, type);
			}
		}
		
		services.AddScoped<IReportRepository, ReportRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ICurrentUserProvider, Common.Services.CurrentUserProvider>();
		
		services.AddHostedService<OutboxMessageProcessor>();
		
		return services;
	}
}
