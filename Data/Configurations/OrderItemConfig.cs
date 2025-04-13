using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fruit_Store_MVC.Data.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Configured composite key for OrderItem using OrderId and ProductId.
            //This ensures that each OrderItem is uniquely identified by the combination of OrderId and ProductId .
            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(10, 2);
        }
    }
}
