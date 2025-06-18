using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : class
    {
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<TEntity>> GetAllAsync(string? includeProperties = null);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
