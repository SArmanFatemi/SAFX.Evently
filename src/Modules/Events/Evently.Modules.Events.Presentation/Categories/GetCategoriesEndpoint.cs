using Evently.Common.Application.Caching;
using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.Categories.GetCategories;
using Evently.Modules.Events.Application.Categories.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

internal sealed class GetCategoriesEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ModulesConfigurations.Categories.BasePath, async (ISender sender, ICacheService cacheService) =>
        {
	        IReadOnlyCollection<CategoryResponse> categories = await cacheService
		        .GetAsync<IReadOnlyCollection<CategoryResponse>>("categories");

	        if (categories is not null)
	        {
		        return Results.Ok(categories);
	        }

            Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery());

            if (result.IsSuccess)
			{
	            await cacheService.SetAsync("categories", result.Value);
            }

            return result.Match(Results.Ok, Common.Presentation.ApiResults.ApiResults.Problem);
        })
        .RequireAuthorization()
        .WithTags(ModulesConfigurations.Categories.Tag);
    }
}
