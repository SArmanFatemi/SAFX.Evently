﻿using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.Events.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal sealed class CreateEventEndpoint : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapPost(ModulesConfigurations.Events.BasePath, async (Request request, ISender sender) =>
			{
				Result<Guid> result = await sender.Send(new CreateEventCommand(
					request.CategoryId,
					request.Title,
					request.Description,
					request.Location,
					request.StartsAtUtc,
					request.EndsAtUtc));

				return result.Match(Results.Ok, ApiResults.Problem);
			})
			.RequireAuthorization(Permissions.ModifyEvents)
			.WithTags(ModulesConfigurations.Events.Tag);
	}

	internal sealed class Request
	{
		public Guid CategoryId { get; init; }

		public string Title { get; init; }

		public string Description { get; init; }

		public string Location { get; init; }

		public DateTime StartsAtUtc { get; init; }

		public DateTime? EndsAtUtc { get; init; }
	}
}
