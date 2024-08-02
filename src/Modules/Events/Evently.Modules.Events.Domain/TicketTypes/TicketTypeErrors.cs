﻿using Evently.Common.Domain.Errors;

namespace Evently.Modules.Events.Domain.TicketTypes;

public static class TicketTypeErrors
{
	public static Error NotFound(Guid ticketTypeId) =>
		Error.NotFound("TicketTypes.NotFound", $"The ticket type with the identifier {ticketTypeId} was not found");
}
