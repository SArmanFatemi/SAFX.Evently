using Evently.Common.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Categories.DomainEvents;

public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}
