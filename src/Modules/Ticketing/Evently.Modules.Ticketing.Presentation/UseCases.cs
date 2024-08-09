using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Ticketing.Presentation;

public static class UseCases
{
	internal static UseCaseConfiguration Cards => new()
	{
		Tag = "Cards",
		BasePath = "/users"
	};
	
	internal static UseCaseConfiguration Orders => new()
	{
		Tag = "Orders",
		BasePath = "/orders"
	};
	
	internal static UseCaseConfiguration Tickets => new()
	{
		Tag = "Tickets",
		BasePath = "/tickets"
	};
}
