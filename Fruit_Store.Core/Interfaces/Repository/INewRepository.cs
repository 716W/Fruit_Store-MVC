using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface INewRepository : IGenericRepository<New, int>
    {
        Task<bool> UpdateAsync(int id, New news);
    }
}
