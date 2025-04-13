using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fruit_Store_MVC.Data.Configurations
{
    public class NewsConfig : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CreatedDate).HasDefaultValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
        }
    }
}
