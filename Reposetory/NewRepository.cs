using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;

namespace Fruit_Store_MVC.Reposetory
{
    public class NewRepository : GenericReposetory<New, int>, INewRepository
    {
        private readonly AppDbContext _context;
        public NewRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> UpdateAsync(int id, New news)
        {
            var existingEntity = await GetByIdAsync(x => x.Id == id);
            if (existingEntity == null) return false;
            _context.Entry(existingEntity).CurrentValues.SetValues(news);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
