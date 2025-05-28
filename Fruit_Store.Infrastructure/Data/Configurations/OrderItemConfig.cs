using FruitStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitStore.Infrastructure.Data.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => new { x.Id});
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(10, 2);
        }
    }
}
