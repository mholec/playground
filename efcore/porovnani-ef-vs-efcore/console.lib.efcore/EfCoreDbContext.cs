using console.lib.model;
using Microsoft.EntityFrameworkCore;

namespace console.lib.efcore
{
    public class EfCoreDbContext : DbContext
    {
	    private readonly string connectionString;

		public DbSet<Order> Orders { get; set; }
	    public DbSet<OrderItem> OrderItems { get; set; }

	    public EfCoreDbContext(string connectionString)
	    {
		    this.connectionString = connectionString;
	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<OrderItem>()
			    .HasOne(x => x.Order)
			    .WithMany(x => x.Items)
			    .HasForeignKey(x => x.OrderId);
			    //.IsRequired() // není nutné pro INT, kde je jasné null /  not null
			    ;

			base.OnModelCreating(modelBuilder);
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseSqlServer(connectionString);

		    base.OnConfiguring(optionsBuilder);
	    }
    }
}
