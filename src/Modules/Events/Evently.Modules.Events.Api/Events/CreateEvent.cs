using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

public static class CreateEvent
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("evnents", async (Request request, EventDbContext dbContext) =>
			{
				var @event = new Event
				{
					Id = Guid.NewGuid(),
					Title = request.Title,
					Description = request.Description,
					Location = request.Location,
					StartAtUtc = request.StartAtUtc,
					EndAtUtc = request.EndAtUtc,
					Status = EventStatus.Draft
				};

				dbContext.Events.Add(@event);
				await dbContext.SaveChangesAsync();

				return Results.Ok(@event.Id);
			})
			.WithTags(Tags.Events);
	}

	internal sealed record Request(string Title, string Description, string Location, DateTime StartAtUtc, DateTime EndAtUtc);
}
