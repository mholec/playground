using Microsoft.Extensions.Logging;

namespace EFCoreDemo.Data.Logging
{
    public class SqlQueryLogProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SqlLogger();
        }
    }
}