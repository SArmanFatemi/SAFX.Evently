using Evently.Modules.Events.Application.Abstractions.Clock;
using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Categories;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Domain.TicketTypes;
using Evently.Modules.Events.Infrastructure.Categories;
using Evently.Modules.Events.Infrastructure.Clock;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Database.Data;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Infrastructure.TicketTypes;
using Evently.Modules.Events.Presentation.Categories;
using Evently.Modules.Events.Presentation.Events;
using Evently.Modules.Events.Presentation.TicketTypes;
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
	public static void MapEndpoints(IEndpointRouteBuilder app)
	{
		TicketTypeEndpoints.MapEndpoints(app);
		CategoryEndpoints.MapEndpoints(app);
		EventEndpoints.MapEndpoints(app);
	}

	public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
		});

		services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
		services.AddInfrastructure(configuration);

		return services;
	}

	private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		string databaseConnectionString = configuration.GetConnectionString("Database")!;

		NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
		services.TryAddSingleton(npgsqlDataSource);

		services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

		services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

		services.AddDbContext<EventDbContext>(options =>
			options
				.UseNpgsql(
					databaseConnectionString,
					npgsqlOptions => npgsqlOptions
						.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
				.UseSnakeCaseNamingConvention()
				.AddInterceptors());

		// Add Unit of work and repositories
		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventDbContext>());

		services.AddScoped<IEventRepository, EventRepository>();
		services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();
	}
}
