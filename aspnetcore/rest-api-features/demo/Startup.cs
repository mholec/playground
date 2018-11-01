using System;
using demo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseInMemoryDatabase("Teched2018"));
			
            var mvc = services.AddMvc(options =>
            {
                //options.InputFormatters.Add(new XmlSerializerInputFormatter());
                //options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                //options.OutputFormatters.Insert(0,new XmlSerializerOutputFormatter());
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                //options.ReturnHttpNotAcceptable = true;

	            //options.CacheProfiles.Add("Default", new CacheProfile(){Duration = 1200});
            });

            mvc.AddJsonOptions(options =>
            {
				if (options.SerializerSettings.ContractResolver != null)
				{
					options.SerializerSettings.ContractResolver = new DefaultContractResolver()
					{
						NamingStrategy = new CamelCaseNamingStrategy()
						//NamingStrategy = new SnakeCaseNamingStrategy(),
					};
				}
			});

            services.AddCors(o =>
            {
                o.AddPolicy("Default", cfg =>
                {
                    cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

	        services.AddLocalization();

	        services.AddResponseCaching();

            mvc.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var problemDetails = new ValidationProblemDetails(context.ModelState)
					{
						Instance = context.HttpContext.Request.Path,
						Status = StatusCodes.Status400BadRequest,
						Type = "https://asp.net/core",
						Detail = "Please refer to the errors property for additional details."
					};

					return new BadRequestObjectResult(problemDetails)
					{
						ContentTypes = { "application/problem+json", "application/problem+xml" }
					};
				};
			});

			services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GunShop API", Version = "v1" });
            });


	        // api versioning
	        // https://github.com/Microsoft/aspnet-api-versioning?WT.mc_id=-blog-scottha

	        services.AddApiVersioning(
		        o =>
		        {
			        o.AssumeDefaultVersionWhenUnspecified = true;
			        o.DefaultApiVersion = new ApiVersion(1, 0);
		        } );
        }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseResponseCaching();

	        var requestLocalizationOptions = new RequestLocalizationOptions
	        {
		        DefaultRequestCulture = new RequestCulture("cs-cz"),
	        };
	        requestLocalizationOptions.RequestCultureProviders.Clear();
	        requestLocalizationOptions.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
	        requestLocalizationOptions.AddSupportedCultures("cs-cz", "en-us");
	        requestLocalizationOptions.AddSupportedUICultures("cs-cz", "en-us");
	        app.UseRequestLocalization(requestLocalizationOptions);

	        app.UseCors("Default");

			app.UseMvc();

			//app.UseHttpCacheHeaders();

			app.UseDeveloperExceptionPage();


            //app.UseExceptionHandler(exc =>
            //      {
            //       exc.Run(async context =>
            //       {
            //        context.Response.StatusCode = 500;
            //        await context.Response.WriteAsync("Unexpected error happened");
            //       });
            //      });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GunShop API V1");
            });
        }
    }
}
