using FruitStore.Core.Models;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category,int>
    {
        Task<bool> UpdateAsync(int id, Category category);
    }
}
