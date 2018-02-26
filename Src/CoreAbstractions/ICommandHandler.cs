using System.Threading.Tasks;

namespace CoreAbstractions
{
    /// <summary>
    /// Command represents a change in state to the system. Can be async.
    /// </summary>
    /// <typeparam name="TCommand">The type of the TCommand.</typeparam>
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }

    public interface ICommandHandlerAsync<in TCommand>
    {
        Task Handle(TCommand command);
    }
}