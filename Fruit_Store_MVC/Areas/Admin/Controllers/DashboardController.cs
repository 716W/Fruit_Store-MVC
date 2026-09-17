using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IOrderServices _orderServices;

        public DashboardController(IProductServices productServices, ICategoryServices categoryServices,
            IOrderServices orderServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetAllAsync();
            var categories = await _categoryServices.GetAll();
            var orders = await _orderServices.GetAllAsync();

            ViewBag.ProductCount = products.Count();
            ViewBag.CategoryCount = categories.Count();
            ViewBag.OrderCount = orders.Count();
            ViewBag.PendingOrderCount = orders.Count(o => o.Status == FruitStore.Core.Enums.OrderStatus.Pending);
            ViewBag.Revenue = orders
                .Where(o => o.Status != FruitStore.Core.Enums.OrderStatus.Cancelled)
                .Sum(o => o.TotalAmount);

            return View();
        }
    }
}
