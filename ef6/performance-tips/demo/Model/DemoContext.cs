using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

	    public DemoContext(string connectionString) : base(connectionString)
	    {
	    }

		public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.UserGroups).WithRequired(x => x.User).HasForeignKey(x=> x.UserId);
            modelBuilder.Entity<Group>().HasMany(x => x.UserGroups).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
        }
    }
}
