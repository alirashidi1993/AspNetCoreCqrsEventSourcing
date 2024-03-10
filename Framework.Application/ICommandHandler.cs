using MediatR;

namespace Framework.Application
{
    public interface ICommandHandler<T> : IRequestHandler<T> where T : Command
    {
    }
}
