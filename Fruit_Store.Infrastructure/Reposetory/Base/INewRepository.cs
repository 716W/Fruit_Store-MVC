using FruitStore.Infrastructure.Reposetory.Base;
using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface INewRepository : IGenericRepository<New, int>
    {
        Task<bool> UpdateAsync(int id, New news);
    }
}
