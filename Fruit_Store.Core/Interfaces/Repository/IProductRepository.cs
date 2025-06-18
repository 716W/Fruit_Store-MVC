using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<bool> UpdateAsync(int id, Product product);
    }
}
