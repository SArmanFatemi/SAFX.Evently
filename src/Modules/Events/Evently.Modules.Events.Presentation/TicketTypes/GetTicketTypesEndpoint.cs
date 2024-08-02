﻿using Evently.Common.Domain.Abstractions;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.TicketTypes.GetTicketType;
using Evently.Modules.Events.Application.TicketTypes.GetTicketTypes;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.TicketTypes;

internal sealed class GetTicketTypesEndpoint : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapGet(ModulesConfigurations.TicketTypes.BasePath, async (Guid eventId, ISender sender) =>
			{
				Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(
					new GetTicketTypesQuery(eventId));

				return result.Match(Results.Ok, Common.Presentation.ApiResults.ApiResults.Problem);
			})
			.WithTags(ModulesConfigurations.TicketTypes.Tag);
	}
}