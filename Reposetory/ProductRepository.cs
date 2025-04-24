using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;

namespace Fruit_Store_MVC.Reposetory
{
    public class ProductRepository : GenericReposetory<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAsync(int id, Product product)
        {
            var existingEntity = await GetByIdAsync(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
