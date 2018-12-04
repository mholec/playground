using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WinService.HostedServices.FileWriter
{
	public class FileWriterService : IHostedService, IDisposable
	{
		private const string Path = @"d:\TestApplication.txt";

		private Timer timer;

		public Task StartAsync(CancellationToken cancellationToken)
		{
			timer = new Timer(
				(e) => WriteTimeToFile(),
				null,
				TimeSpan.Zero,
				TimeSpan.FromMinutes(1));

			return Task.CompletedTask;
		}

		public void WriteTimeToFile()
		{
			if (!File.Exists(Path))
			{
				using (var sw = File.CreateText(Path))
				{
					sw.WriteLine(DateTime.UtcNow.ToString("O"));
				}
			}
			else
			{
				using (var sw = File.AppendText(Path))
				{
					sw.WriteLine(DateTime.UtcNow.ToString("O"));
				}
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			timer?.Change(Timeout.Infinite, 0);

			return Task.CompletedTask;
		}

		public void Dispose()
		{
			timer?.Dispose();
		}
	}
}