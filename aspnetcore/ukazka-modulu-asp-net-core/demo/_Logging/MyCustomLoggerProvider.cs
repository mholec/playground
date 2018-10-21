using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace UkazkaAspNetCore._Logging
{
	public class MyCustomLoggerProvider : ILoggerProvider
	{
		private readonly MyCustomLoggerConfig config;
		private readonly ConcurrentDictionary<string, MyCustomLogger> loggers = new ConcurrentDictionary<string, MyCustomLogger>();

		public MyCustomLoggerProvider(MyCustomLoggerConfig config)
		{
			this.config = config;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return loggers.GetOrAdd(categoryName, name => new MyCustomLogger(name, config));
		}

		public void Dispose()
		{
			loggers.Clear();
		}
	}
}
