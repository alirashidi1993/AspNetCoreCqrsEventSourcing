using Framework.Domain;
using System.Reflection;

namespace Framework.Core
{
    public class AggregateFactory : IAggregateFactory
    {
        public T Create<T>(List<DomainEvent> events) where T : IAggregateRoot
        {
            var aggregate = (T)Activator.CreateInstance(typeof(T), true);

            foreach (var domainEvent in events)
            {
                aggregate?.Apply(domainEvent);
            }
            return aggregate;
        }
    }
}