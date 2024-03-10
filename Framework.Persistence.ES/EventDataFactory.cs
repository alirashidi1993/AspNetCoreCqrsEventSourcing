
using EventStore.Client;
using Framework.Domain;
using Newtonsoft.Json;
using System.Text;

namespace Framework.Persistence.ES
{
    internal static class EventDataFactory
    {
        public static EventData CreateFrom(DomainEvent domainEvent)
        {
            EventData eventPayload = GenerateEventData(domainEvent);
            return eventPayload;
        }
        public static IEnumerable<EventData> CreateFrom(IEnumerable<DomainEvent> domainEvents)
        {
            var events = domainEvents.Select(GenerateEventData);
            return events;
        }

        private static EventData GenerateEventData(DomainEvent domainEvent)
        {
            var json = JsonConvert.SerializeObject(domainEvent);
            var jsonBytes = Encoding.UTF8.GetBytes(json);

            var eventPayload = new EventData(
                Uuid.NewUuid(),
                domainEvent.GetType().Name,
                jsonBytes);

            return eventPayload;
        }
    }
}