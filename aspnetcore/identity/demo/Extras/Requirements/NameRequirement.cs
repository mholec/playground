using Microsoft.AspNetCore.Authorization;

namespace demo.Extras.Requirements
{
	public class NameRequirement : IAuthorizationRequirement
	{
		public string Name { get; private set; }

		public NameRequirement(string name)
		{
			this.Name = name;
		}
	}
}