using System.Reflection;

namespace Evently.Modules.Attendance.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Attendance.Domain.AssemblyReference).Assembly;

    protected static readonly Assembly ApplicationAssembly = typeof(Attendance.Application.AssemblyReference).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Attendance.Presentation.AssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(Attendance.Infrastructure.AssemblyReference).Assembly;
}
