using FruitStore.Core.Models;
using FruitStore.Fruit_Store.Infrastructure.Data;
using Fruit_Store.Core.Interfaces.Repository;

namespace FruitStore.Infrastructure.Reposetory
{
    public class CategoryRepository : GenericReposetory<Category,int> , ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAsync(int id, Category category)
        {
            var existingEntity = await Get(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
