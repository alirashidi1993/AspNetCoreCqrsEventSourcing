
using Framework.Core;
using Framework.Domain;
using System.Reflection;

namespace Framework.Persistence.ES
{
    public class EventTypeResolver : IEventTypeResolver
    {
        private Dictionary<string, Type> types = new Dictionary<string, Type>();
        public void AddTypesFromAssembly(Assembly assembly)
        {
            var events = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(DomainEvent))).ToList();
            events.ForEach(e =>
            {
                types.Add(e.Name, e);
            });
        }

        public Type GetType(string typeName)
        {
            return types.ContainsKey(typeName)? types[typeName]:null;
        }
    }
}
