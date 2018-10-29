using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace UkazkaAspNetCore._HttpContext
{
	public class CustomService
	{
		private readonly IHttpContextAccessor httpContextAccessor;

		public CustomService(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}

		public IIdentity GetIdentity()
		{
			return httpContextAccessor.HttpContext.User.Identity;
		}
	}
}
