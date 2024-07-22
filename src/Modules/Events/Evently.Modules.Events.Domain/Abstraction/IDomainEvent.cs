namespace Evently.Modules.Events.Domain.Abstraction;

public interface IDomainEvent
{
	Guid Id { get; }

	DateTime OccurredAtUtc { get; }
}