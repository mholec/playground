using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace UkazkaAspNetCore
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((host, config) =>
					{
						config.SetBasePath(Directory.GetCurrentDirectory());
						config.AddEnvironmentVariables("CUSTOM_");
						config.AddInMemoryCollection(new Dictionary<string, string>() { { "SmtpSettings:SmtpUser", "mirek c#" } });
						config.AddXmlFile($"settings.xml", true, false);
						config.AddIniFile("settings.ini", true, false);
						config.AddIniFile($"settings.{host.HostingEnvironment.EnvironmentName}.ini", true, false);
						config.AddCommandLine(args);
					})
				//.UseKestrel(options =>
				//{
				//	options.Listen(IPAddress.Loopback, 5000);
				//	options.Listen(IPAddress.Loopback, 5001, opt =>
				//	{
				//		opt.UseHttps("certificate.pfx", "password");
				//	});
				//})
				.UseApplicationInsights()
				.UseStartup<Startup>();
	}
}
