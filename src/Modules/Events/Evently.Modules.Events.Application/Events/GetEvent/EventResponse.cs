namespace Evently.Modules.Events.Application.Events.GetEvent;

public record EventResponse(Guid Id, string Title, string Description, string Location, DateTime StartAtUtc, DateTime? EndAtUtc);