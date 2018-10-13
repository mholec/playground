using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lib.Model
{
	public class AppDbContext : DbContext
	{
		// Model Collections
		public DbSet<Eshop> Eshops { get; set; }
		public DbSet<Product> Products { get; set; }

		// Unit Testing
		public AppDbContext()
		{
		}

		// Ctor
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging(true);

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
