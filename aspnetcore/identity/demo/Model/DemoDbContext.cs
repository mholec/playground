using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Model.CustomIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace demo.Model
{
	public class DemoDbContext : IdentityDbContext<WebAppUser, WebAppRole, string>
	{
		public DemoDbContext()
		{
			
		}

		public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<WebAppUser>(x =>
			{
				x.HasMany(user => user.Claims)
					.WithOne()
					.HasForeignKey(uc => uc.UserId)
					.IsRequired();

				x.HasMany(e => e.UserRoles)
					.WithOne()
					.HasForeignKey(ur => ur.Id)
					.IsRequired();
			});
		}
	}
}
