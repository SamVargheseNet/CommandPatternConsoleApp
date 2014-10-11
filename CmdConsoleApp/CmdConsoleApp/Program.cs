using CmdConsoleApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ICommandFactory> availableCommands = GetAvailableCommands();

            if (args.Length == 0)
            {
                PrintUsage(availableCommands);
                return;
            }

            CommandParser parser = new CommandParser(availableCommands);
            ICommand command = parser.ParseCommand(args);

            command.Execute();
            Console.ReadKey();
        }

        static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
                        {
                            new RunAllQueries()
                        };
        }

        private static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("Usage: LoggingDemo CommandName Arguments");
            Console.WriteLine("Commands:");
            foreach (ICommandFactory command in availableCommands)
                Console.WriteLine("  {0}", command.Description);
        }

    }
}
