using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CoreVersions
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        var current = Assembly.GetExecutingAssembly();
	        var whb = Assembly.GetAssembly(typeof(WebHostBuilder));
	        var all = AppDomain.CurrentDomain.GetAssemblies().Select(x=> x.FullName);


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(all, new JsonSerializerSettings()
                {
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            });
        }
    }
}
