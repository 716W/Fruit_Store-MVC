using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store.Infrastructure.Reposetory;
using FruitStore.Fruit_Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FruitStore.Infrastructure.Reposetory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private IDbContextTransaction? _currentTransaction;

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

        public async Task BeginTransactionAsync()
        {
            if (_db.Database.IsRelational() && _currentTransaction == null)
            {
                _currentTransaction = await _db.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.RollbackAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }
    }
}

