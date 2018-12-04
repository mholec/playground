using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using demo.Filters;
using demo.Services;
using demo.Services.Generators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace demo
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			// jedine pravidlo je, že by se neměla scoped / transient service volat ze singleton scope
			//services.AddScoped<IScopedGuidGen, GuidGen>();
			services.AddTransient<ITransientGuidGen, GuidGen>();
			services.AddSingleton<ISingletonGuidGen, GuidGen>();
			services.AddTransient<GuidService, GuidService>();

	        services.AddTransient<MyActionFilter>();

	        services.AddMvc();

			// custom container service, windsor: https://www.nuget.org/packages/Castle.Windsor.MsDependencyInjection
	        WindsorContainer container = new WindsorContainer();
	        container.Register(Component
		        .For<IScopedGuidGen>()
		        .ImplementedBy<GuidGen>()
		        .LifestyleCustom<MsScopedLifestyleManager>() // ScopedLifestyle (per web request execution - MsLifetimeScope)
	        );

	        IServiceProvider serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);

			return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	        app.UseDeveloperExceptionPage();

	        app.UseMvc();
        }
    }
}
