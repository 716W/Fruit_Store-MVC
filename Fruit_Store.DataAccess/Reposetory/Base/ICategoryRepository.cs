using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface ICategoryRepository : IGenericRepository<Category,int>
    {
        Task<bool> UpdateAsync(int id, Category category);
    }
}
