using FruitStore.Fruit_Store.Infrastructure.Data;
using FruitStore.Infrastructure.Reposetory.Base;


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
        }
        public IProductRepository Product { get; private set; }

        public IReviewRepository Review { get; private set; }

        public INewRepository New { get; private set; }

        public ICategoryRepository Category {  get; private set; }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
