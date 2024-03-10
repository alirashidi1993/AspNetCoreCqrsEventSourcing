using Framework.Domain;

namespace Framework.Core
{
    public interface IAggregateFactory
    {
        T Create<T>(List<DomainEvent> events) where T : IAggregateRoot;
    }
}