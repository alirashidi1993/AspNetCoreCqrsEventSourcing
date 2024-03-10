using System.Reflection;

namespace Framework.Core
{
    public interface IEventTypeResolver
    {
        void AddTypesFromAssembly(Assembly assembly);
        Type GetType(string typeName);
    }
}
