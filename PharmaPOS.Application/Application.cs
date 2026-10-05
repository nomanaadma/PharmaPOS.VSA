using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using PharmaPOS.Application.Common.Behaviors;
using PharmaPOS.Application.Common.Services;

namespace PharmaPOS.Application;

public static class ApplicationServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly(); 
		
		var scopedServices = assembly.GetTypes()
			.Where(t => t is { IsClass: true, IsAbstract: false } && typeof(IApplicationService).IsAssignableFrom(t));

		foreach (var type in scopedServices)
		{
			services.AddScoped(type);
		}

		// Register MediatR handlers and Pipeline Behaviors
		services.AddMediatR(cfg => {
			cfg.RegisterServicesFromAssembly(assembly);
			cfg.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
			cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});

		// Register FluentValidation validators
		services.AddValidatorsFromAssembly(assembly);
		
		var config = TypeAdapterConfig.GlobalSettings;
		config.Scan(assembly);
		
		return services;
	}
}