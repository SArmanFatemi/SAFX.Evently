using System.Reflection;

namespace Evently.Modules.Ticketing.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
