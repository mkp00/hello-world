using CoreAbstractions;
using Infrastructure.QryHandlers;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using System;
using CoreDetails;
using Infrastructure.CmdHandlers;
using Services;

namespace Console.CommandLines
{
    /// <summary>
    /// Represents text typed into the command prompt to execute an application.
    /// This class cannot be inherited.
    /// </summary>
    public sealed class PrintToConsoleCmdLine
    {
        private IServiceProvider serviceProvider;

        public static void Create(CommandLineApplication cmdLineApp)
        {
            var cmd = new PrintToConsoleCmdLine();
            AddOptions(cmdLineApp, cmd);

            cmdLineApp.OnExecute(() =>
            {
                try
                {
                    ConfigureServices(cmd);
                    cmd.serviceProvider.GetService<IService>().Run();
                    return 0;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"Unhandled exception thrown during execution of OnExecute callback. {e.ToString()}");
                    return 1;
                }
            });
        }

        /// <summary>
        /// Adds the options.
        /// </summary>
        /// <param name="cmdLineApp">The command line application object.</param>
        /// <param name="cmd">The command line instance being executed.</param>
        internal static void AddOptions(CommandLineApplication cmdLineApp, PrintToConsoleCmdLine cmd)
        {
            //Define command line Options or Arguments
            cmdLineApp.Description = "Prints 'Hello World' on the console screen."; //part of help

            //Can add line argument or option here if need to take string from command line input or other sources i.e. config file
        }

        /// <summary>
        /// Parses the command line.
        /// </summary>
        /// <param name="cmd">The command line instance being executed.</param>
        //internal static void ParseCommandLine(PrintToScreenCmdLine cmd)
        //{
        //}

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="cmd">The command line instance being executed.</param>
        //internal static void ConfigureApplication(PrintToScreenCmdLine cmd)
        //{
        //}

        internal static void ConfigureServices(PrintToConsoleCmdLine cmd)
        {
            cmd.serviceProvider = new ServiceCollection()
                .AddSingleton<IQueryHandler<PrintToScreenData>, HelloWorldQryHandler>()
                .AddSingleton<ICommandHandler<PrintToScreenData>, PrintToConsoleCmdHandler>()
                .AddSingleton<IService, PrintToScreenService>()
                .BuildServiceProvider();
        }
    }
}