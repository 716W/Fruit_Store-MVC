using FruitStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FruitStore.Infrastructure.Data.Configurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
        }
    }
}
