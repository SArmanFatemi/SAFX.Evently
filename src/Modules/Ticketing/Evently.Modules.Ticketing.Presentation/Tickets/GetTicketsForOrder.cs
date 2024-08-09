using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Ticketing.Application.Tickets.GetTicket;
using Evently.Modules.Ticketing.Application.Tickets.GetTicketForOrder;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicketsForOrder : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapGet(UseCases.Tickets.BasePath + "/order/{orderId}", async (Guid orderId, ISender sender) =>
			{
				Result<IReadOnlyCollection<TicketResponse>> result = await sender.Send(
					new GetTicketsForOrderQuery(orderId));

				return result.Match(Results.Ok, ApiResults.Problem);
			})
			.RequireAuthorization()
			.WithTags(UseCases.Tickets.Tag);
	}
}
