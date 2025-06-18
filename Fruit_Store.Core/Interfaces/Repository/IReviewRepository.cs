using FruitStore.Core.Models;

namespace Fruit_Store.Core.Interfaces.Repository
{
    public interface IReviewRepository : IGenericRepository<Review , int>
    {
        Task<bool> UpdateAsync(int id, Review review);
    }
}
