namespace Fruit_Store_MVC.Reposetory.Base
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
