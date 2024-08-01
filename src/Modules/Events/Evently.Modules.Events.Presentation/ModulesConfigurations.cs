namespace Evently.Modules.Events.Presentation;

internal static class ModulesConfigurations
{
	internal static ModuleConfiguration Events => new()
	{
		Tag = "Events",
		BasePath = "/events"
	};

	internal static ModuleConfiguration Categories => new()
	{
		Tag = "Categories",
		BasePath = "/categories"
	};

	internal static ModuleConfiguration TicketTypes => new()
	{
		Tag = "TicketTypes",
		BasePath = "/ticket-types"
	};
}

internal sealed class ModuleConfiguration
{
	public string Tag { get; init; }
	public string BasePath { get; init; }
}
