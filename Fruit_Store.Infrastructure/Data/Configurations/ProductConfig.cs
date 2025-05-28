using FruitStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitStore.Infrastructure.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            //builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            //builder.Property(x => x.Price).IsRequired().HasPrecision(6, 2);
            //builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(0);
            //builder.Property(x => x.ImageUrl).IsRequired(false);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.ImageUrl).IsRequired(false);
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);  // Specify delete behavior as needed
        }
    }
    
}
