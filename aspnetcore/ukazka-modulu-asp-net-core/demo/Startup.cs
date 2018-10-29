using System;
using System.Net;
using System.Net.Mail;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UkazkaAspNetCore._Configuration;
using UkazkaAspNetCore._DependencyInjection;
using UkazkaAspNetCore._ErrorHandling;
using UkazkaAspNetCore._HttpContext;
using UkazkaAspNetCore._Localization;
using UkazkaAspNetCore._Logging;
using UkazkaAspNetCore._Middlewares;

namespace UkazkaAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
	        Environment = environment;

        }

        public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });





	        // CONFIGURATION OPTIONS
	        services.Configure<AppSettings>(Configuration); // root
	        services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings")); // section





	        // DEPENDENCY INJECTION - CUSTOM SERVICES
	        services.AddScoped<CustomService>();



			// DEPENDENCY INJECTION - ENVIRONMENT VARIABLES
			if (Environment.IsProduction())
	        {
		        services.AddTransient<IMailer, BetterSmtpServerMailer>();
	        }
	        else
	        {
		        services.AddScoped<IMailer, ConsoleMailer>();
			}



			// DEPENDENCY INJECTION - FRAMEWORK ITFS.
			services.AddScoped<SmtpClient>((serviceProvider) =>
	        {
		        SmtpSettings smtp = new SmtpSettings();
		        Configuration.GetSection("SmtpSettings").Bind(smtp); // Bind to class
				return new SmtpClient()
		        {
			        Port = smtp.SmtpPort,
			        Host = Configuration["SmtpSettings.SmtpServer"],
					Credentials = new NetworkCredential(smtp.SmtpUser, smtp.SmtpPassword)
		        };
	        });





	        // HTTP CONTEXT
	        services.AddHttpContextAccessor();





			// LOCALIZATION
	        services.Configure<RequestLocalizationOptions>(options =>
	        {
				options.DefaultRequestCulture = new RequestCulture("cs-CZ");
	        });

	        services.AddLocalization(options => options.ResourcesPath = "Resources");



			services.AddMvc()
				.AddViewLocalization()
				.AddDataAnnotationsLocalization(options =>
				{
					options.DataAnnotationLocalizerProvider = (type, factory) =>
						factory.Create(typeof(SharedAnnotations));
				})

				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

	        return services.BuildServiceProvider();
        }

		public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
	        loggerFactory.AddConsole(Configuration); // default
	        loggerFactory.AddDebug(); // default
	        loggerFactory.AddEventSourceLogger();
			loggerFactory.AddApplicationInsights(app.ApplicationServices);
	        loggerFactory.AddAzureWebAppDiagnostics();

			// CUSTOM LOGGER
	        //loggerFactory.AddProvider(new MyCustomLoggerProvider(new MyCustomLoggerConfig()));

			// ERROR HANDLING
            if (Environment.IsDevelopment())
            {
	            app.UseDeveloperExceptionPage();
	            //app.UseSimpleExceptionPageMiddleware();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


			// MIDDLEWARES
			//app.Use(async (httpContext, next) =>
			//{
			//	// before
			//	await httpContext.Response.WriteAsync("Before event \n");

			//	// continue in next middleware
			//	await next.Invoke();

			//	// after
			//	await httpContext.Response.WriteAsync("After event \n");
			//});

			//app.UseExampleMiddleware();

			//app.Run(async context =>
			//{
			//	await context.Response.WriteAsync("App Run fired \n");
			//});

			app.Map("/handle/xyz", ExampleHandle.HandleXyz);

			// app.MapWhen(context => context.Request.GetUri().AbsolutePath.Contains("handle/"), ExampleHandle.HandleXyz);

			//app.UseAuthentication();



			// LOCALIZATION
			var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
	        app.UseRequestLocalization(options.Value);




			// MVC
			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

