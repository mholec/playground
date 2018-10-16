using demo.ApiModels;
using Microsoft.EntityFrameworkCore;

namespace demo.Repositories
{
    public class Context : DbContext
    {
		public DbSet<Product> Products { get; set; }
		public DbSet<Tag> Tags { get; set; }

        public Context() : base()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
