﻿using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.Events.SearchEvents;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal sealed class SearchEventsEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ModulesConfigurations.Events.BasePath + "/search", async(
            ISender sender,
            Guid ? categoryId,
            DateTime? startDate,
            DateTime? endDate,
            int page = 0,
            int pageSize = 15) =>
        {
            Result<SearchEventsResponse> result = await sender.Send(
                new SearchEventsQuery(categoryId, startDate, endDate, page, pageSize));

            return result.Match(Results.Ok, Common.Presentation.ApiResults.ApiResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(ModulesConfigurations.Events.Tag);
    }
}
