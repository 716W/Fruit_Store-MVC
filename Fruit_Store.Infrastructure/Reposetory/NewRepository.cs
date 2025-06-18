using FruitStore.Core.Models;
using FruitStore.Infrastructure.Data;
using FruitStore.Fruit_Store.Infrastructure.Data;
using Fruit_Store.Core.Interfaces.Repository;

namespace FruitStore.Infrastructure.Reposetory
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
            var existingEntity = await Get(x => x.Id == id);
            if (existingEntity == null) return false;
            _context.Entry(existingEntity).CurrentValues.SetValues(news);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
