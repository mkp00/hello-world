using System;
using CoreAbstractions;
using CoreDetails;

namespace Services
{
    /// <summary>
    /// Class PrintToScreenService prints a string to the screen using the provided ICommandHandler.
    /// </summary>
    /// <seealso cref="CoreAbstractions.IService" />
    public class PrintToScreenService : IService
    {
        private readonly ICommandHandler<PrintToScreenData> printCmdHandler;
        private readonly IQueryHandler<PrintToScreenData> printQryHandler;

        public PrintToScreenService(IQueryHandler<PrintToScreenData> printQryHandler, ICommandHandler<PrintToScreenData> printCmdHandler)
        {
            this.printQryHandler = printQryHandler ?? throw new ArgumentNullException(nameof(printQryHandler));
            this.printCmdHandler = printCmdHandler ?? throw new ArgumentNullException(nameof(printCmdHandler));
        }

        /// <summary>
        /// Runs this instance. Currently, overkill for the current requirements, but demonstrates how
        /// services can be composed from commands and queries and other services to represent business functionality.
        /// </summary>
        public void Run()
        {
            printCmdHandler.Handle(printQryHandler.Handle());
        }
    }
}