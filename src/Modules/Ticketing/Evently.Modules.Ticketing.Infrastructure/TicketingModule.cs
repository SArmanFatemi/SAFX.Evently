using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Ticketing.Application.Carts;
using Evently.Modules.Ticketing.Presentation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Ticketing.Infrastructure;

public static class TicketingModule
{
	public static IServiceCollection AddTicketingModule(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddInfrastructure(configuration);

		services.AddEndpoints(AssemblyReference.Assembly);

		return services;
	}

#pragma warning disable S1172
#pragma warning disable IDE0060
	private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
#pragma warning restore IDE0060
#pragma warning restore S1172
	{
		services.AddSingleton<CartService>();
	}
}
