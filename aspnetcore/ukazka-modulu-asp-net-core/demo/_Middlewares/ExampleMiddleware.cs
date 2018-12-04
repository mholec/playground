using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace UkazkaAspNetCore._Middlewares
{
	public class ExampleMiddleware
	{
		private readonly RequestDelegate next;

		// Služby se injectují přes Invoke, pokud by byly v ctoru, staly by se singletonem!
		public ExampleMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			// before
			await httpContext.Response.WriteAsync("Before event middleware class \n");

			// continue in next middleware
			await next.Invoke(httpContext);

			// after
			await httpContext.Response.WriteAsync("After event middleware class \n");
		}
	}

	public static class ExampleMiddlewareExtensions
	{
		public static IApplicationBuilder UseExampleMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExampleMiddleware>();
		}
	}
}
