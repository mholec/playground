using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            
            builder.Property(x => x.OrderId).ValueGeneratedNever();

            //builder.Property(x => x.OrderState).HasConversion(new EnumToStringConverter<OrderState>());
            builder.Property(x => x.OrderState).HasConversion<int>().HasDefaultValue(OrderState.Done);

            builder.Property(x => x.OrderNo).HasDefaultValueSql("NEXT VALUE FOR dbo.OrderNumbers");
            
            builder.OwnsOne(x => x.Price);
            builder.OwnsOne(x => x.BillingAddress);
            builder.OwnsOne(x => x.ShippingAddress, sa =>
            {
                sa.Ignore(x => x.Email);
            });
            

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }
}