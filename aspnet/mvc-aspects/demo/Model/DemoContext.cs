using System.Data.Entity;

namespace Model
{
    public class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
