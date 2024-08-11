using Evently.Common.Domain;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Attendance.Application.Abstractions.Authentication;
using Evently.Modules.Attendance.Application.Attendees.CheckInAttendee;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Attendance.Presentation.Attendees;

internal sealed class CheckInAttendee : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ModulesConfigurations.Attendees.BasePath + "/check-in", async (
                Request request,
                IAttendanceContext attendanceContext,
                ISender sender) =>
        {
            Result result = await sender.Send(
                new CheckInAttendeeCommand(attendanceContext.AttendeeId, request.TicketId));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .RequireAuthorization(Permissions.CheckInTicket)
        .WithTags(ModulesConfigurations.Attendees.Tag);
    }

    internal sealed class Request
    {
        public Guid TicketId { get; init; }
    }
}
