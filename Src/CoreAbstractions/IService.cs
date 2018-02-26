namespace CoreAbstractions
{
    /// <summary>
    /// Services are built using ICommandHandlers and IQueryHandlers and/or composed
    /// from other services. They can represent a business transaction/function. Can be async.
    /// </summary>
    public interface IService
    {
        void Run();
    }
}