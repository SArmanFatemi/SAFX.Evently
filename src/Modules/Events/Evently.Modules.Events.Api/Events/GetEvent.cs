using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Events;

public static class GetEvent
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("events/{id}", async (Guid id, EventDbContext db) =>
		{
			EventResponse? @event = await db.Events
				.Where(e => e.Id == id)
				.Select(e => new EventResponse(e.Id, e.Title, e.Description, e.Location, e.StartAtUtc, e.EndAtUtc))
				.SingleOrDefaultAsync();

			return @event == null ? Results.NotFound() : Results.Ok(@event);
		})
		.WithTags(Tags.Events);
	}
}
