using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;
using Fruit_Store_MVC.Services.Base;

namespace Fruit_Store_MVC.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> FilterByTypeAsync(string type)
        {
            var All = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");

            return All.Where(p => p.Name.Contains(type)).ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return (await _unitOfWork.Product.GetAllAsync(includeProperties: "Category"));
        }
    }
}