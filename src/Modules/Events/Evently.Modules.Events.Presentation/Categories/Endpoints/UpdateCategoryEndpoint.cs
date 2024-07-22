using Evently.Modules.Events.Application.Categories.UpdateCategory;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories.Endpoints;

internal sealed class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut( CategoryEndpoints.BasePath + "/{id}", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}
