using Fruit_Store_MVC.Models;
using Fruit_Store_MVC.Reposetory.Base;
using Fruit_Store_MVC.Services.Base;
using Fruit_Store_MVC.ViewModels;

namespace Fruit_Store_MVC.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HomeViewModel> GetHomePageDataAsync()
        {
            // Use OfType<Model>() to safely filter and cast only Model items 
            // from a generic collection (e.g., IEnumerable<object>) returned by the repository

            var Prducts = (await _unitOfWork.Product.GetAllAsync()).OfType<Product>().ToList();
            var Reviews = (await _unitOfWork.Review.GetAllAsync()).OfType<Review>().ToList();
            var News = (await _unitOfWork.New.GetAllAsync()).OfType<New>().ToList();

            var homeViewModel = new HomeViewModel
            {
                Products = Prducts ,
                Reviews = Reviews,
                News = News
            };

            return homeViewModel;
        }
    }
}
