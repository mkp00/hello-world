using Console.CommandLines;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace Console
{
    class Program
    {
        private static CommandLineApplication commandLineApplication;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Console   Start");
            ConfigureCommandLine();
            AddCommands();
            System.Console.WriteLine("Executing Print To Console Command");
            ExecuteCommands(new []{ "PrintToConsole" });
            System.Console.WriteLine("Console   End");
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();
        }

        /// <summary>
        /// Configures the command line.
        /// </summary>
        static void ConfigureCommandLine()
        {
            commandLineApplication = new CommandLineApplication()
            {
                Name = "Console",
                Description = "Executes commands."
            };

            commandLineApplication.OnExecute(() =>
            {
                System.Console.WriteLine("No command was found in the command line args. Application requires a command.");
                commandLineApplication.ShowHelp();
                return 1;
            });
        }

        /// <summary>
        /// Adds the commands that can be executed by this console.
        /// </summary>
        static void AddCommands()
        {
            commandLineApplication.Command("PrintToConsole", PrintToConsoleCmdLine.Create);
        }

        /// <summary>
        /// Executes the commands typed into the console.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void ExecuteCommands(string[] args)
        {
            Environment.ExitCode = 1;
            try
            {
                System.Console.WriteLine(commandLineApplication.FullName + " " + commandLineApplication.Description);
                System.Console.WriteLine("Command Line: " + args.Aggregate("", (a, b) => a.Length == 0 ? b : a + " " + b));
                Environment.ExitCode = commandLineApplication.Execute(args);
            }
            catch (CommandParsingException e)
            {
                System.Console.WriteLine($"Exception thrown while parsing command line arguments. {e.ToString()}");
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Unhandled exception thrown during execution. {e.ToString()}");
            }
        }
    }
}
