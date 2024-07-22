using Evently.Modules.Events.Presentation.Events.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

public static class EventsEndpoints
{
	internal static string BasePath => "events";
	
	public static void MapEndpoints(IEndpointRouteBuilder app)
	{
		CreateEventEndpoint.Map(app);
		GetEventEndpoint.Map(app);
	}
}
