﻿using Evently.Common.Domain.Abstractions;
using Evently.Modules.Events.Application.TicketTypes.CreateTicketType;
using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes.Endpoints;

internal sealed class CreateTicketTypeEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	{
		app.MapPost(TicketTypeEndpoints.BasePath, async (Request request, ISender sender) =>
			{
				Result<Guid> result = await sender.Send(new CreateTicketTypeCommand(
					request.EventId,
					request.Name,
					request.Price,
					request.Currency,
					request.Quantity));

				return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
			})
			.WithTags(Tags.TicketTypes);
	}

	internal sealed class Request
	{
		public Guid EventId { get; init; }

		public string Name { get; init; }

		public decimal Price { get; init; }

		public string Currency { get; init; }

		public decimal Quantity { get; init; }
	}
}
