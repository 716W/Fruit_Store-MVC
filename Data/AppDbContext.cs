using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Fruit_Store_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // Create Model :

    }
}
