using Framework.Domain;

namespace Framework.Core
{
    public interface IEventStore
    {
        Task<List<DomainEvent>> GetEventsOfStream(string streamId);
        Task AppendEvents(string streamId, IEnumerable<DomainEvent> events);
    }
}