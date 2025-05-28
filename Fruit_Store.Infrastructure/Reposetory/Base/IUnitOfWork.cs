using Fruit_Store.Infrastructure.Reposetory.Base;
using FruitStore.Core.Models;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Reposetory.Base
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        ICouponRepository Coupon { get; }
        IReviewRepository Review { get; }
        INewRepository New { get; }
        ICategoryRepository Category { get; }
        Task SaveAsync();
    }
}
