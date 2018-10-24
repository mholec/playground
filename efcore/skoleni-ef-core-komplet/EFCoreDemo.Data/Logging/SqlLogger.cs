using System;
using Microsoft.Extensions.Logging;

namespace EFCoreDemo.Data.Logging
{
    public class SqlLogger : ILogger
    {
        public const string CommandExecutingEventName = "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting";
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Name == CommandExecutingEventName)
            {
                string message = state.ToString();
                
                message = message.Substring(message.IndexOf("\n", StringComparison.InvariantCulture) + 1);

                Console.WriteLine("- - - - - SQL Command - - - - -");
                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.WriteLine(message);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}