using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fruit_Store_MVC.Data.Configurations
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
