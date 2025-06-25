using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FruitStore.Core.Models;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Fruit_Store_MVC.ViewModels;

namespace FruitStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;
        private readonly INewServices _newsServices;
        private readonly IReviewServices _reviewServices;

        public HomeController(ILogger<HomeController> logger, INewServices newsServices, IReviewServices reviewServices , IProductServices productServices)
        {
            _logger = logger;
            _newsServices = newsServices;
            _reviewServices = reviewServices;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetAllAsync();
            var news = await _newsServices.GetLastAsync();
            var reviews = await _reviewServices.GetLastReviewsAsync();

            var viewModel = new HomeViewModel
            {
                Products = products,
                News = news,
                Reviews = reviews
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
