using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Data;
using Microsoft.AspNetCore.Authorization;

namespace demo.Extras.AuthHandlers
{
	public class DocumentAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Document>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameAuthorRequirement requirement, Document resource)
		{
			if (context.User.Identity?.Name == resource.AuthorName)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}

	public class SameAuthorRequirement : IAuthorizationRequirement { }
}
