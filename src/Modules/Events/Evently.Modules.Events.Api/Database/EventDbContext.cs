using Evently.Modules.Events.Api.Events;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Database;

public sealed class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options)
{
	internal DbSet<Event> Events { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Events);
	}
}