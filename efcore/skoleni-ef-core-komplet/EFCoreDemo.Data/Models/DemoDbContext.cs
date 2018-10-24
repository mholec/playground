using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using EFCoreDemo.Data.Logging;
using EFCoreDemo.Data.Models.Mapping;
using EFCoreDemo.Data.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreDemo.Data.Models
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {

        }
        
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbQuery<ProductImagesCounts> ProductImagesCounts { get; set; }
        public DbSet<Relation> Relations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] {new SqlQueryLogProvider()}));
            //optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            // nuget Install-Package Microsoft.EntityFrameworkCore.Proxies -Version 2.1.0-rc1-final
            //optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasKey(x => x.BrandId);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.HasSequence<int>("OrderNumbers", schema: "dbo")
                .StartsAt(20180001)
                .IncrementsBy(1);
            
            // mapping
            modelBuilder.ApplyConfiguration(new BrandMapping());
            modelBuilder.ApplyConfiguration(new CategoryDetailMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ImageMapping());
            modelBuilder.ApplyConfiguration(new OrderItemMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new RelationMapping());

	        modelBuilder.Ignore<PersonData>();

            // mapping views
            modelBuilder.Query<ProductImagesCounts>()
                .ToView("View_ProductImagesCounts")
                .Property(x => x.SeoLink).HasColumnName("SeoLink");

            base.OnModelCreating(modelBuilder);
        }
    }
}