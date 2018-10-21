using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace UkazkaAspNetCore._Middlewares
{
	public static class ExampleHandle
	{
		public static void HandleXyz(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				await context.Response.WriteAsync("HandleXyz");
			});
		}
	}
}
