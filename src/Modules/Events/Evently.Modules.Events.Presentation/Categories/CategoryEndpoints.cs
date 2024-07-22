using Evently.Modules.Events.Presentation.Abstractions.Endpoints;
using Evently.Modules.Events.Presentation.Categories.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

public class CategoryEndpoints : IEndpointsMapper
{
	public static string BasePath => "categories";
	
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        ArchiveCategoryEndpoint.Map(app);
        CreateCategoryEndpoint.Map(app);
        GetCategoryEndpoint.Map(app);
        GetCategoriesEndpoint.Map(app);
        UpdateCategoryEndpoint.Map(app);
    }
}
