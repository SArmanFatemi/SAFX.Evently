using System.Reflection;
using Evently.ArchitectureTests.Abstractions;
using Evently.Modules.Users.Domain;
using NetArchTest.Rules;

namespace Evently.ArchitectureTests.Layers;

public class ModuleTests : BaseTest
{
    [Fact]
    public void UsersModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [EventsNamespace, TicketingNamespace, AttendanceNamespace];
        string[] integrationEventsModules = [
            EventsIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace,
            AttendanceIntegrationEventsNamespace];

        List<Assembly> usersAssemblies =
        [
	        AssemblyReference.Assembly,
	        Modules.Users.Application.AssemblyReference.Assembly,
	        Modules.Users.Presentation.AssemblyReference.Assembly,
	        Modules.Users.Infrastructure.AssemblyReference.Assembly
        ];

        Types.InAssemblies(usersAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void EventsModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, TicketingNamespace, AttendanceNamespace];
        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace,
            AttendanceIntegrationEventsNamespace];

        List<Assembly> eventsAssemblies =
        [
	        Modules.Events.Domain.AssemblyReference.Assembly,
	        Modules.Events.Application.AssemblyReference.Assembly,
	        Modules.Events.Presentation.AssemblyReference.Assembly,
	        Modules.Events.Infrastructure.AssemblyReference.Assembly
        ];

        Types.InAssemblies(eventsAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void TicketingModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, EventsNamespace, AttendanceNamespace];
        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace,
            EventsIntegrationEventsNamespace,
            AttendanceIntegrationEventsNamespace];

        List<Assembly> ticketingAssemblies =
        [
	        Modules.Ticketing.Domain.AssemblyReference.Assembly,
	        Modules.Ticketing.Application.AssemblyReference.Assembly,
	        Modules.Ticketing.Presentation.AssemblyReference.Assembly,
	        Modules.Ticketing.Infrastructure.AssemblyReference.Assembly
        ];

        Types.InAssemblies(ticketingAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void AttendanceModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [UsersNamespace, EventsNamespace, TicketingNamespace];
        string[] integrationEventsModules = [
            UsersIntegrationEventsNamespace,
            EventsIntegrationEventsNamespace,
            TicketingIntegrationEventsNamespace];

        List<Assembly> attendanceAssemblies =
        [
	        Modules.Attendance.Domain.AssemblyReference.Assembly,
            Modules.Attendance.Application.AssemblyReference.Assembly,
            Modules.Attendance.Presentation.AssemblyReference.Assembly,
	        Modules.Attendance.Infrastructure.AssemblyReference.Assembly
        ];

        Types.InAssemblies(attendanceAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
