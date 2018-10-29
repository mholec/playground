using System;
using Microsoft.Extensions.Logging;

namespace UkazkaAspNetCore._Logging
{
	public class MyCustomLogger : ILogger
	{
		private MyCustomLoggerConfig config;
		private string categoryName;

		public MyCustomLogger(string categoryName, MyCustomLoggerConfig config)
		{
			this.categoryName = categoryName;
			this.config = config;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}
	}
}