using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.Events.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

public class EventEndpoints : IEndpointsMapper
{
	public static string BasePath => "events";

	public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CancelEventEndpoint.Map(app);
        CreateEventEndpoint.Map(app);
        GetEventEndpoint.Map(app);
        GetEventsEndpoint.Map(app);
        PublishEventEndpoint.Map(app);
        RescheduleEventEndpoint.Map(app);
        SearchEventsEndpoint.Map(app);
    }
}
