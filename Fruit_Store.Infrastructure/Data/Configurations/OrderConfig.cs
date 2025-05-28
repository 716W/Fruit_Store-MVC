using FruitStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitStore.Infrastructure.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderDate).IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.TotalAmount).IsRequired().IsRequired()
                .HasPrecision(10, 2);
            builder.Property(x => x.Status).IsRequired(false);

        }
    }
}
