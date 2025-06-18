using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store.Infrastructure.Reposetory;
using FruitStore.Fruit_Store.Infrastructure.Data;


namespace FruitStore.Infrastructure.Reposetory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            Review = new ReviewRepository(_db);
            New = new NewRepository(_db);
            Category = new CategoryRepository(_db);
            Order = new OrderRepository(_db);
            OrderItem = new OrderItemRepository(_db);
            Coupon = new CouponRepository(_db);
        }
        public IProductRepository Product { get; private set; }

        public IReviewRepository Review { get; private set; }

        public INewRepository New { get; private set; }

        public ICategoryRepository Category {  get; private set; }

        public IOrderRepository Order { get; private set; }

        public IOrderItemRepository OrderItem { get; private set; }

        public ICouponRepository Coupon { get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
