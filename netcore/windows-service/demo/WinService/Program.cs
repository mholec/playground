using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinService.HostedServices.FileWriter;
using WinService.Infrastructure;

namespace WinService
{
	internal class Program
	{
		private static async Task Main(string[] args)
		{
			bool isService = !(Debugger.IsAttached || args.ToList().Contains("--console"));

			IHostBuilder builder = new HostBuilder()
				.ConfigureAppConfiguration(o => o.AddIniFile("appsettings.ini", false))
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<FileWriterService>();
				});

			if (isService)
			{
				await builder.RunAsServiceAsync();
			}
			else
			{
				await builder.RunConsoleAsync();
			}
		}
	}
}
