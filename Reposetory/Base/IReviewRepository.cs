using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fruit_Store_MVC.Reposetory.Base
{
    public interface IReviewRepository : IGenericRepository<Review , int>
    {
        Task<bool> UpdateAsync(int id, Review review);
    }
}
