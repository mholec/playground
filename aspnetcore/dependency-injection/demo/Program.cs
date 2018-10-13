using System;
using demo.Services.Generators;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        var host = CreateWebHostBuilder(args).Build();

			// dočasný scope
			using (var serviceScope = host.Services.CreateScope())
	        {
		        var services = serviceScope.ServiceProvider;

		        try
		        {
			        var serviceContext = services.GetRequiredService<ISingletonGuidGen>();
			        var guid = serviceContext.GetGuid();
		        }
		        catch (Exception)
		        {
			        // ignored
		        }
	        }

	        host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
