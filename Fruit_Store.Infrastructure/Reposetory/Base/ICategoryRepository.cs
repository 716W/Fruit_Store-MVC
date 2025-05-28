using FruitStore.Infrastructure.Reposetory;
using FruitStore.Core.Models;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface ICategoryRepository : IGenericRepository<Category,int>
    {
        Task<bool> UpdateAsync(int id, Category category);
    }
}
