using Evently.Modules.Events.Api.Database;
using Evently.Modules.Events.Api.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Api;

public static class EventsModule
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		CreateEvent.MapEndpoint(app);
		GetEvent.MapEndpoint(app);
	}
	
	public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
	{
		string? connectionString = configuration.GetConnectionString("Database");
		if (connectionString is null)
		{
			throw new NullReferenceException("Connection string is not found in the configuration");
		}
		
		services.AddDbContext<EventDbContext>(options =>
		{
			options.UseNpgsql(connectionString, npgsqlOption =>
			{
				npgsqlOption.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events);
			}).UseSnakeCaseNamingConvention();
		});
		return services;
	}
}
