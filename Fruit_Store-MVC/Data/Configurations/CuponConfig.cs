using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fruit_Store_MVC.Data.Configurations
{
    public class CuponConfig : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DiscountPercentage).IsRequired()
                .HasPrecision(5, 2); // Max (100%) .

            builder.Property(x => x.ExpiryDate).IsRequired();

            builder.Property(x => x.IsActived).IsRequired()
                .HasDefaultValue(true);
        }
    }
}
