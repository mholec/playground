using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddScoped<DownloadWebsiteService>();

	        services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
	        app.UseMvc();
        }
    }
}
