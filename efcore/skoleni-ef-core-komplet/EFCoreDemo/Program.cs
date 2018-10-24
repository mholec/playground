using System;
using EFCoreDemo.Data.Models;
using EFCoreDemo.Data.Models.Init;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCoreDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            InitDatabase(host);

            host.Run();
        }

        private static void InitDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DemoDbContext>();
                    DbInitializer.Initialize(context);

                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        private static IWebHost BuildWebHost(string[] args) => WebHost
                .CreateDefaultBuilder(args) // provede základní konfiguraci, načtení JSON, env variables, logování
                .UseStartup<Startup>() // registruje Startup jako singleton, dopraví do něj závislosti a volá metody Configure + ConfigureServices
                .Build(); // vytvoří WebHost
    }
}