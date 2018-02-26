using CoreAbstractions;
using CoreDetails;

namespace Infrastructure.QryHandlers
{
    /// <summary>
    /// Class HelloWorldQryHandler represents a basic query handler for 'Hello World'.
    /// </summary>
    /// <seealso cref="PrintToScreenData" />
    public class HelloWorldQryHandler : IQueryHandler<PrintToScreenData>
    {
        /// <summary>
        /// Handles this instance.
        /// </summary>
        /// <returns>PrintToScreenData.</returns>
        public PrintToScreenData Handle()
        {
            //Data is statically generated, but could just as easily come from a database or webservice.
            return new PrintToScreenData("Hello World", 0);
        }
    }
}