using System;
using System.Security.Claims;
using demo.Model;
using demo.Model.CustomIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<DemoDbContext>(opt =>
			{
				opt.UseInMemoryDatabase("identity-demo");
			});

	        services.AddIdentity<WebAppUser, WebAppRole>()
		        .AddEntityFrameworkStores<DemoDbContext>()
		        .AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(opt =>
			{
				// Password settings.
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequiredLength = 3;
				opt.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				opt.Lockout.MaxFailedAccessAttempts = 5;
				opt.Lockout.AllowedForNewUsers = true;

				// User settings.
				opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				opt.User.RequireUniqueEmail = false;
			});

			services.ConfigureApplicationCookie(opt =>
			{
				// Cookie settings
				opt.Cookie.HttpOnly = true;
				opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				opt.LoginPath = "/account/login";
				opt.LogoutPath = "/account/logout";
				opt.AccessDeniedPath = "/account/accessdenied";
				opt.SlidingExpiration = true;
			});

	        services.AddAuthorization(options =>
	        {
				options.AddPolicy("CustomPolicy", policy =>
				{
					policy
						.RequireRole("Administrator")
						.RequireClaim(ClaimTypes.Role, "Editor");
				});
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