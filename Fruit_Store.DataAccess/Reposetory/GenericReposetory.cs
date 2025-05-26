using Fruit_Store_MVC.Data;
using Fruit_Store_MVC.Reposetory.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Fruit_Store_MVC.Reposetory
{
    public class GenericReposetory<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly AppDbContext _context;
        public GenericReposetory(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            // if u want to filter the query, pass the filter as a parameter
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }
        // if u want navagation properties to be included in the query, pass them as a comma-separated string
        public async Task<IEnumerable<TEntity>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }
        public async Task<bool> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(TEntity Entity)
        {
            _context.Remove(Entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
