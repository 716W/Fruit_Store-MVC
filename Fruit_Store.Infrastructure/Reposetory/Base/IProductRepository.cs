using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<bool> UpdateAsync(int id, Product product);
    }
}
