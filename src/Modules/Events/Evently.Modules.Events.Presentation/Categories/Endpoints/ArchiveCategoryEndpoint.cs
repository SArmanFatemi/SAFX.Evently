using Evently.Modules.Events.Application.Categories.ArchiveCategory;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories.Endpoints;

internal sealed class ArchiveCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut(CategoryEndpoints.BasePath + "/{id}/archive", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new ArchiveCategoryCommand(id));

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
