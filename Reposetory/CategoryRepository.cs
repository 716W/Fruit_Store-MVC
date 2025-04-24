using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;

namespace Fruit_Store_MVC.Reposetory
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
            var existingEntity = await GetByIdAsync(x => x.Id == id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
