namespace Framework.Domain
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
        }
        public Guid EventId { get; }
    }
}
