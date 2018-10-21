using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace UkazkaAspNetCore._ErrorHandling
{
	public class SimpleExceptionPageMiddleware
	{
		private readonly RequestDelegate next;

		public SimpleExceptionPageMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await this.next(httpContext);
			}
			catch (Exception e)
			{
				httpContext.Response.Clear();
				httpContext.Response.StatusCode = 500;

				await httpContext.Response.WriteAsync(e.Message + "\n\n" + e.StackTrace);

				return;
			}
		}
	}

	public static class SimpleExceptionPageMiddlewareExtensions
	{
		public static IApplicationBuilder UseSimpleExceptionPageMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<SimpleExceptionPageMiddleware>();
		}
	}
}
