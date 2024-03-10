namespace Framework.Core
{
    public interface IEventSourceRepository<T>
    {
        Task<T> GetById(Guid id);
        Task AppendEvents(T aggregateRoot);
    }
}