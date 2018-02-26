namespace CoreAbstractions
{
    /// <summary>
    /// Performs a query of a data source using input from the IQuery object and returns the output.
    /// </summary>
    /// <typeparam name="TQuery">The type of the TQuery input parameter.</typeparam>
    /// <typeparam name="TResult">The type of the TResult output parameter.</typeparam>
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }

    /// <summary>
    /// Performs a query of a data source and returns the output.
    /// </summary>
    /// <typeparam name="TResult">The type of the TResult.</typeparam>
    public interface IQueryHandler<out TResult>
    {
        TResult Handle();
    }
}