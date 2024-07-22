using Evently.Modules.Events.Application.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events.Endpoints;

internal static class GetEventEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapGet(EventsEndpoints.BasePath + "/{id:guid}", async (Guid id, ISender sender) =>
			{
				EventResponse? @event = await sender.Send(new GetEventQuery(id));

				return @event == null ? Results.NotFound() : Results.Ok(@event);
			})
			.WithTags(Tags.Events);
	}
}
