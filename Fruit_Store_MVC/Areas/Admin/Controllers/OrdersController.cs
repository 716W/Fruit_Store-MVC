using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderServices.GetAllAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderServices.GetByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus newStatus)
        {
            var result = await _orderServices.UpdateStatusAsync(id, newStatus);
            if (!result)
                TempData["Error"] = "Order not found.";
            else
                TempData["Success"] = $"Order #{id} status updated to {newStatus}.";

            return RedirectToAction(nameof(Index));
        }
    }
}
