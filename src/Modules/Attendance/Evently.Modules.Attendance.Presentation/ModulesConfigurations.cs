using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Attendance.Presentation;

internal static class ModulesConfigurations
{
	internal static UseCaseConfiguration Attendees => new()
	{
		Tag = "Attendees",
		BasePath = "/attendees"
	};
}
