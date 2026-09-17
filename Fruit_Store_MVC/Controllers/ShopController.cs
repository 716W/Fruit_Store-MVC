using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ShopController(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            var allProducts = await _productServices.GetAllAsync();
            var categories = await _categoryServices.GetAll();

            IEnumerable<ProductDTO> products = categoryId.HasValue
                ? await _productServices.GetByCategoryIdAsync(categoryId.Value)
                : allProducts;

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryId = categoryId;

            return View(products);
        }
    }
}
