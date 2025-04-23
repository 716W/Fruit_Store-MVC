using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Reposetory.Base;
using Microsoft.EntityFrameworkCore;

namespace Fruit_Store_MVC.Reposetory
{
    public class GenericReposetory<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericReposetory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                // Handle the case where the entity is not found, e.g., log or throw an exception if needed.
                return null; // Explicitly return null if not found.
            }
            return entity;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<bool> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(TKey id)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null) return false ;

            _context.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
