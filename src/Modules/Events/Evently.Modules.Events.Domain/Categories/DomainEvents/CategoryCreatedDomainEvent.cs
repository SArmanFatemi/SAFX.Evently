using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Categories.DomainEvents;

public sealed class CategoryCreatedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
