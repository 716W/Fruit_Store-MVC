using System.Linq.Expressions;

namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<TEntity>> GetAllAsync(string? includeProperties = null);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
