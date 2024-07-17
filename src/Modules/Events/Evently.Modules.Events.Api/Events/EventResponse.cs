namespace Evently.Modules.Events.Api.Events;

public record EventResponse(Guid Id, string Title, string Description, string Location, DateTime StartAtUtc, DateTime? EndAtUtc);