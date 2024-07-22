using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Abstractions.Endpoints;

internal interface IEndpointsMapper
{
	static abstract string BasePath { get; }

	static abstract void MapEndpoints(IEndpointRouteBuilder app);
}
