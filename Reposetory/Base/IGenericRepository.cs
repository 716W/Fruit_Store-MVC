namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface IGenericRepository<TEntity , TKey> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey id);
    }
}
