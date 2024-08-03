using Evently.Common.Presentation.Endpoints;

namespace Evently.Modules.Users.Presentation;

internal static class UseCases
{
    internal static UseCaseConfiguration Users => new()
    {
	    Tag = "Users",
	    BasePath = "/users"
    };
}
