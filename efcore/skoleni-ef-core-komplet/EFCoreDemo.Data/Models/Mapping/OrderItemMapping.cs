using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.OrderItemId);

            builder.Property(x => x.Title).HasMaxLength(Product.MaxTitleLength).IsRequired();

            builder.OwnsOne(x => x.Price);
            builder.OwnsOne(x => x.TotalPrice);
            
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.OriginalProduct).WithMany().HasForeignKey(x => x.OriginalProductId);

        }
    }
}