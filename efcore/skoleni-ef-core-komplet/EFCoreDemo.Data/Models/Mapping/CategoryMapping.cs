using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.ToTable("Categories");
            
            builder.HasIndex(x => x.SeoLink).IsUnique().HasName("IX_Category_SeoLink");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SeoLink).IsRequired().HasMaxLength(100);
            
            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.CategoryDetail).WithOne(x => x.Category).HasForeignKey<CategoryDetail>(x => x.CategoryId);
        }
    }
}