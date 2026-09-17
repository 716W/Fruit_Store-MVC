using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class SingleProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IReviewServices _reviewServices;

        public SingleProductController(IProductServices productServices, IReviewServices reviewServices)
        {
            _productServices = productServices;
            _reviewServices = reviewServices;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id <= 0) return NotFound();

            var product = await _productServices.GetByIdAsync(id);
            if (product == null) return NotFound();

            var reviews = await _reviewServices.GetByProductIdAsync(id);
            ViewBag.Reviews = reviews;

            return View(product);
        }
    }
}
