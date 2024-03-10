using EventStore.Client;

using Framework.Core;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public class EventStoreDb : IEventStore
    {
        private readonly EventStoreClient connection;
        private readonly IEventTypeResolver eventTypeResolver;

        public EventStoreDb(EventStoreClient connection,IEventTypeResolver eventTypeResolver)
        {
            this.connection = connection;
            this.eventTypeResolver = eventTypeResolver;
        }



        public async Task AppendEvents(string streamId, IEnumerable<DomainEvent> events)
        {
            var eventData = EventDataFactory.CreateFrom(events);
            await connection.AppendToStreamAsync(streamId,StreamState.Any,eventData);
        }

        public async Task<List<DomainEvent>> GetEventsOfStream(string streamId)
        {
            var events = connection.ReadStreamAsync(Direction.Forwards, streamId, StreamPosition.Start);
            var resolvedEvents = await events.ToListAsync();
            var domainEvents = DomainEventFactory.CreateFrom(resolvedEvents, eventTypeResolver);
            return domainEvents;
        }
    }
}
