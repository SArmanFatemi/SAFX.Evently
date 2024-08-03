using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Ticketing.Presentation;

public static class UseCases
{
	internal static UseCaseConfiguration Cards => new()
	{
		Tag = "Cards",
		BasePath = "/users"
	};
}
