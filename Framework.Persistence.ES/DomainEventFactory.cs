
using EventStore.Client;
using Framework.Core;
using Framework.Domain;
using Framework.Persistence.ES.Mappings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Framework.Persistence.ES
{
    public static class DomainEventFactory
    {
        public static List<DomainEvent> CreateFrom(
            List<ResolvedEvent> resolvedEvents,
            IEventTypeResolver eventTypeResolver)
        {
            var domainEvents = new List<DomainEvent>();
            resolvedEvents.ForEach(e =>
            {
                var type = eventTypeResolver.GetType(e.Event.EventType);
                var body = Encoding.UTF8.GetString(e.Event.Data.ToArray());
                var @event = (DomainEvent)JsonConvert.DeserializeObject(body, type);
                domainEvents.Add(@event);

            });
            return domainEvents;
        }
        public static DomainEvent CreateFrom(
            ResolvedEvent resolvedEvent,
            IEventTypeResolver eventTypeResolver)
        {
            var type = eventTypeResolver.GetType(resolvedEvent.Event.EventType);
            if (type == null)
            {
                return null;
            }
            var body = Encoding.UTF8.GetString(resolvedEvent.Event.Data.ToArray());
            body = ApplyMappings(body, type);
            var @event = (DomainEvent)JsonConvert.DeserializeObject(body, type);
            return @event;
        }

        private static string ApplyMappings(string body, Type type)
        {
            var filter = SchemaMappingRegistrar.GetFilterForType(type);
            if (filter == null) return body;
            var jObj = JObject.Parse(body);
            jObj = filter.Apply(jObj);

            return jObj.ToString();
        }
    }
}