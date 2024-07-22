using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Abstractions.Endpoints;

internal interface IEndpoint
{
	static abstract void Map(IEndpointRouteBuilder app);
}
