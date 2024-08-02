﻿using Evently.Common.Domain.Abstractions;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal sealed class ChangeTicketTypePriceEndpoint : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapPut(ModulesConfigurations.TicketTypes.BasePath + "/{id}/price", async (Guid id, Request request, ISender sender) =>
			{
				Result result = await sender.Send(new UpdateTicketTypePriceCommand(id, request.Price));

				return result.Match(Results.NoContent, Common.Presentation.ApiResults.ApiResults.Problem);
			})
			.WithTags(ModulesConfigurations.TicketTypes.Tag);
	}

	internal sealed class Request
	{
		public decimal Price { get; init; }
	}
}