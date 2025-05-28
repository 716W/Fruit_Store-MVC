using FruitStore.Core.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface IReviewRepository : IGenericRepository<Review , int>
    {
        Task<bool> UpdateAsync(int id, Review review);
    }
}
