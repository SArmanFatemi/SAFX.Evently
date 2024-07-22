using System.Data.Common;
using Dapper;
using Evently.Modules.Events.Application.Abstractions.Data;
using MediatR;

namespace Evently.Modules.Events.Application.Events.GetEvent;

internal sealed class GetEventQueryHandler(IDbConnectionFactory dbConnectionFactory) : IRequestHandler<GetEventQuery, EventResponse?>
{
	public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
	{
		await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync(cancellationToken);

		const string sql =
			$"""
			 SELECT
			     e.id AS {nameof(EventResponse.Id)},
			     e.title AS {nameof(EventResponse.Title)},
			     e.description AS {nameof(EventResponse.Description)},
			     e.location AS {nameof(EventResponse.Location)},
			     e.starts_at_utc AS {nameof(EventResponse.StartAtUtc)},
			     e.ends_at_utc AS {nameof(EventResponse.EndAtUtc)}
			 FROM events.events e
			 WHERE e.id = @EventId
			 """;

		EventResponse? @event = await connection.QuerySingleOrDefaultAsync(sql, request);

		return @event;
	}
}