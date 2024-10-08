using Evently.Modules.Attendance.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Ticketing.Infrastructure.Database;
using Evently.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extensions;

internal static class MigrationExtensions
{
	public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
	{
		using IServiceScope scope = app.ApplicationServices.CreateScope();
		scope.ApplyMigration<EventsDbContext>();
		scope.ApplyMigration<UsersDbContext>();
		scope.ApplyMigration<TicketingDbContext>();
		scope.ApplyMigration<AttendanceDbContext>();
	}

	private static void ApplyMigration<TDbContext>(this IServiceScope scope)
		where TDbContext : DbContext
	{
		using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
		context.Database.Migrate();
	}
}
