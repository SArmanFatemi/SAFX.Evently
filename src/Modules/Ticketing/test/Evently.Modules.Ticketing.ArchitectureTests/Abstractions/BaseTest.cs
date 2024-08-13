using System.Reflection;

namespace Evently.Modules.Ticketing.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Ticketing.Domain.AssemblyReference).Assembly;

    protected static readonly Assembly ApplicationAssembly = typeof(Ticketing.Application.AssemblyReference).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Ticketing.Presentation.AssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(Ticketing.Infrastructure.AssemblyReference).Assembly;
}
