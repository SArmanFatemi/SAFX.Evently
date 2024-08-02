﻿using Evently.Common.Domain.Abstractions;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.TicketTypes.GetTicketType;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal sealed class GetTicketTypeEndpoint : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapGet(ModulesConfigurations.TicketTypes.BasePath + "/{id}", async (Guid id, ISender sender) =>
			{
				Result<TicketTypeResponse> result = await sender.Send(new GetTicketTypeQuery(id));

				return result.Match(Results.Ok, Common.Presentation.ApiResults.ApiResults.Problem);
			})
			.WithTags(ModulesConfigurations.TicketTypes.Tag);
	}
}