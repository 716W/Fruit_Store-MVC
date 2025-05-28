using FruitStore.Core.Models;
using FruitStore.Fruit_Store.Infrastructure.Data;
using FruitStore.Infrastructure.Data;
using FruitStore.Infrastructure.Reposetory.Base;

namespace FruitStore.Infrastructure.Reposetory
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
            var existingEntity = await Get(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
