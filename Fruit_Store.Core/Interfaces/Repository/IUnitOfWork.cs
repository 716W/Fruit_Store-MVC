namespace Fruit_Store.Core.Interfaces.Repository
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
