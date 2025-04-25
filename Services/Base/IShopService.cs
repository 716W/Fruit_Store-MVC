using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;

namespace Fruit_Store_MVC.Services.Base
{
    public interface IShopService
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<IEnumerable<Product>> FilterByTypeAsync(string name);
    }
}
