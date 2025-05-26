using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<bool> UpdateAsync(int id, Product product);
    }
}
