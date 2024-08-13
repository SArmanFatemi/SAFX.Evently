using System.Reflection;

namespace Evently.Modules.Events.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Events.Application.AssemblyReference).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(Events.Domain.AssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(Events.Infrastructure.AssemblyReference).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Events.Presentation.AssemblyReference).Assembly;
}
