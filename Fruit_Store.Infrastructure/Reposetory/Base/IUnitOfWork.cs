using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IReviewRepository Review { get; }
        INewRepository New { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
