﻿using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Ticketing.Application.Orders.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Ticketing.Presentation.Orders;

internal sealed class GetOrder : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapGet(UseCases.Orders + "/{id}", async (Guid id, ISender sender) =>
			{
				Result<OrderResponse> result = await sender.Send(new GetOrderQuery(id));

				return result.Match(Results.Ok, ApiResults.Problem);
			})
			.RequireAuthorization()
			.WithTags(UseCases.Orders.Tag);
	}
}
