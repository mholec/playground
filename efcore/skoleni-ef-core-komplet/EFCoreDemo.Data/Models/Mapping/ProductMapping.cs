using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            
            builder.HasIndex(x => x.SeoLink).IsUnique();
            
            builder.Property(x => x.Title).IsRequired().HasMaxLength(Product.MaxTitleLength);
            builder.Property(x => x.SeoLink).IsRequired().HasMaxLength(100);

            builder.Ignore(x => x.TemporaryNotes);

            builder.OwnsOne(x => x.Price, price =>
            {
                price.Property(x=> x.BasePrice).HasColumnType("decimal(10, 2)").HasDefaultValue(0);
                price.Property(x=> x.VatRate).HasColumnType("decimal(4, 3)");
            });

            builder.Property(x => x.ProductWarehouseIdent)
                .HasComputedColumnSql("'PRD-' + [SeoLink]")
                .HasColumnType("nvarchar(200)");

            builder.HasMany(x => x.Images).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Brand).WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandIdentifier)
                .HasPrincipalKey(x => x.BrandIdentifier)
                .IsRequired(); // mapování na základě stringu = povinnost musí být expl. uvedena
        }
    }
}