using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Services.Base
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
