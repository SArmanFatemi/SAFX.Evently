using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Events.Presentation;

internal static class ModulesConfigurations
{
	internal static UseCaseConfiguration Events => new()
	{
		Tag = "Events",
		BasePath = "/events"
	};

	internal static UseCaseConfiguration Categories => new()
	{
		Tag = "Categories",
		BasePath = "/categories"
	};

	internal static UseCaseConfiguration TicketTypes => new()
	{
		Tag = "TicketTypes",
		BasePath = "/ticket-types"
	};
}
