using Evently.Modules.Events.Application.Events.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class CreateEvent
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("evnents", async (Request request, ISender sender) =>
			{
				CreateEventCommand command = new(
					request.Title,
					request.Description,
					request.Location,
					request.StartAtUtc,
					request.EndAtUtc);
				Guid eventId = await sender.Send(command);

				return Results.Ok(eventId);
			})
			.WithTags(Tags.Events);
	}

	internal sealed record Request(
		string Title,
		string Description,
		string Location,
		DateTime StartAtUtc,
		DateTime EndAtUtc);
}
