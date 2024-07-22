using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Database;

namespace Evently.Modules.Events.Infrastructure.Events;

public class EventRepository(EventDbContext dbContext) : IEventRepository
{
	public void Insert(Event @event)
	{
		dbContext.Events.Add(@event);
	}
}
