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

        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	    app.UseDeveloperExceptionPage();

	    var assemblies = AppDomain.CurrentDomain.GetAssemblies().Select(x=> x.FullName);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(assemblies, new JsonSerializerSettings()
                {
		   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            });
        }
    }
}
