using System.Reflection;

namespace Evently.Modules.Users.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Users.Domain.AssemblyReference).Assembly;

    protected static readonly Assembly ApplicationAssembly = typeof(Users.Application.AssemblyReference).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Users.Presentation.AssemblyReference).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(Users.Infrastructure.AssemblyReference).Assembly;
}
