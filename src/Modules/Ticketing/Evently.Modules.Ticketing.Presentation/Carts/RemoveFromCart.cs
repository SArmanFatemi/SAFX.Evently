﻿using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Ticketing.Application.Abstractions.Authentication;
using Evently.Modules.Ticketing.Application.Carts.RemoveItemFromCart;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Ticketing.Presentation.Carts;

internal sealed class RemoveFromCart : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapPut(UseCases.Cards.BasePath + "/remove",
				async (Request request, ICustomerContext customerContext, ISender sender) =>
				{
					Result result = await sender.Send(
						new RemoveItemFromCartCommand(customerContext.CustomerId, request.TicketTypeId));

					return result.Match(Results.NoContent, ApiResults.Problem);
				})
			.RequireAuthorization(Permissions.RemoveFromCart)
			.WithTags(UseCases.Cards.Tag);
	}

	internal sealed class Request
	{
		public Guid TicketTypeId { get; init; }
	}
}
