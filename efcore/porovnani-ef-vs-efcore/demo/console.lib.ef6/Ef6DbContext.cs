using System;
using System.Data.Entity;
using console.lib.model;

namespace console.lib.ef6
{
    public class Ef6DbContext : DbContext
    {
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		    
	    public Ef6DbContext(string connectionString) : base(connectionString)
	    {
			Database.SetInitializer<Ef6DbContext>(new CreateDatabaseIfNotExists<Ef6DbContext>());
	    }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<OrderItem>()
			    .HasOptional(x => x.Order)
			    .WithMany(x => x.Items)
			    .HasForeignKey(x => x.OrderId);

		    base.OnModelCreating(modelBuilder);
	    }
    }
}
