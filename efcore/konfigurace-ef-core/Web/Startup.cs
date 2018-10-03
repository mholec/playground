using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			// jak konfigurovat kontext tak, aby
			// bylo možné jej použít v mvc
			// bylo možné jej použít pro testování
			// bylo možné používat seedování

	        services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseDeveloperExceptionPage();
	        app.UseMvc();
        }
    }
}
