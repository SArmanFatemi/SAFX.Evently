using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions.Data;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Database.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
	public async ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
	{
		return await dataSource.OpenConnectionAsync(cancellationToken);
	}
}
