using Evently.Modules.Events.Domain.Abstraction;

namespace Evently.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
	private Event()
	{
	}

	public Guid Id { get; private set; }

	public string Title { get; private set; }

	public string Description { get; private set; }

	public string Location { get; private set; }

	public DateTime StartAtUtc { get; private set; }

	public DateTime? EndAtUtc { get; private set; }

	public EventStatus Status { get; private set; }

	public static Event Create(
		string title,
		string description,
		string location,
		DateTime startAtUtc,
		DateTime? endAtUtc)
	{
		var @event = new Event
		{
			Id = Guid.NewGuid(),
			Title = title,
			Description = description,
			Location = location,
			StartAtUtc = startAtUtc,
			EndAtUtc = endAtUtc,
			Status = EventStatus.Draft
		};

		@event.Raise(new EventCreatedDomainEvent(@event.Id));

		return @event;
	}
}