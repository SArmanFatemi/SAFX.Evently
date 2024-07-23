using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.TicketTypes.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

public class TicketTypeEndpoints : IEndpointsMapper
{
	public static string BasePath => "ticket-types";

	public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        ChangeTicketTypePriceEndpoint.Map(app);
        CreateTicketTypeEndpoint.Map(app);
        GetTicketTypeEndpoint.Map(app);
        GetTicketTypesEndpoint.Map(app);
    }
}
