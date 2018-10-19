using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace demo.Model.CustomIdentity
{
	public class WebAppUser : IdentityUser
	{
		[PersonalData]
		public string Name { get; set; }

		public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
		public virtual ICollection<WebAppRole> UserRoles { get; set; }
	}
}
