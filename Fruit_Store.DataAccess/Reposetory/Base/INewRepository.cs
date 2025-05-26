using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface INewRepository : IGenericRepository<New, int>
    {
        Task<bool> UpdateAsync(int id, New news);
    }
}
