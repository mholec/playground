using System;
using Microsoft.AspNetCore.Authentication.Cookies;
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
	        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
		        .AddCookie(options =>
		        {
					options.AccessDeniedPath = "/account/accessdenied";
			        options.LoginPath = "/account/login";
			        options.LogoutPath = "/account/logout";
					options.Cookie.Expiration = TimeSpan.FromDays(365);
					//options.Cookie.Domain = "miroslavholec.cz";
		        });

	        services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	        app.UseCookiePolicy(new CookiePolicyOptions()
	        {
				// MinimumSameSitePolicy = SameSiteMode.Strict
	        });

			app.UseDeveloperExceptionPage();

	        app.UseAuthentication(); // v pipeline vždy před AddMvc()

	        app.UseMvc();
        }
    }
}