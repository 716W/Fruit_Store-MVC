using Fruit_Store.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IOrderServices orderServices, UserManager<IdentityUser> userManager)
        {
            _orderServices = orderServices;
            _userManager = userManager;
        }

        /// <summary>Lists only the current user's orders — never other users' orders.</summary>
        public async Task<IActionResult> MyOrders()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null) return Challenge();

            var orders = await _orderServices.GetAllByUserIdAsync(userId);
            return View(orders);
        }

        /// <summary>Shows order details — enforces ownership: user can only see their own orders.</summary>
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);
            var order = await _orderServices.GetByIdAsync(id);

            // Ownership check — prevents IDOR
            if (order == null || order.UserId != userId)
                return NotFound();

            return View(order);
        }
    }
}
