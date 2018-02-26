using System;
using CoreAbstractions;
using CoreDetails;

namespace Infrastructure.CmdHandlers
{
    /// <summary>
    /// Class PrintToScreenCmdHandler.
    /// </summary>
    /// <seealso cref="PrintToScreenData" />
    public class PrintToConsoleCmdHandler : ICommandHandler<PrintToScreenData>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="printToScreenData">The command to execute</param>
        public void Handle(PrintToScreenData printToScreenData)
        {
            if (printToScreenData == null)
            {
                throw new ArgumentNullException(nameof(printToScreenData));
            }

            for (int i = 0; i < printToScreenData.Repeats ; i++)
            {
                System.Console.WriteLine(printToScreenData.PrintText);
            }
        }
    }
}