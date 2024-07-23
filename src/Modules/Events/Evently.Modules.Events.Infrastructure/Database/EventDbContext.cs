using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Domain.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Infrastructure.Database;

public sealed class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options), IUnitOfWork
{
	internal DbSet<Event> Events { get; set; } = null!;
	
	internal DbSet<TicketType> TicketTypes { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Events);
	}
}
