using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Database.Data;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModule
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		EventsEndpoints.MapEndpoints(app);
	}

	public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
		});

		services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
		services.AddInfrastructure(configuration);

		return services;
	}

	private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		string? connectionString = configuration.GetConnectionString("Database");
		if (connectionString is null)
		{
			throw new NullReferenceException("Connection string is not found in the configuration");
		}

		NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
		services.TryAddSingleton(dataSource);

		services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

		services.AddDbContext<EventDbContext>(options =>
		{
			options.UseNpgsql(connectionString, npgsqlOption =>
			{
				npgsqlOption.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events);
			}).UseSnakeCaseNamingConvention();
		});

		services.AddScoped<IEventRepository, EventRepository>();
		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventDbContext>());
	}
}
