using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Services;
using Fruit_Store_MVC.Services;
using Fruit_Store_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly CartService _cartService;
        private readonly IOrderServices _orderServices;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckOutController(CartService cartService, IOrderServices orderServices,
            UserManager<IdentityUser> userManager)
        {
            _cartService = cartService;
            _orderServices = orderServices;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cart = _cartService.GetCart();

            if (!cart.Any())
            {
                TempData["CartError"] = "Your cart is empty. Add some products before checking out.";
                return RedirectToAction("Index", "Cart");
            }

            var user = await _userManager.GetUserAsync(User);

            var viewModel = new CheckoutViewModel
            {
                CartItems = cart,
                Email = user?.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var cart = _cartService.GetCart();

            if (!cart.Any())
            {
                TempData["CartError"] = "Your cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            // Re-attach cart items for view re-render if validation fails
            model.CartItems = cart;

            if (!ModelState.IsValid)
                return View(model);

            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Challenge();

            // Build the order items — server-side prices fetched in service
            var cartItemsForOrder = cart.Select(c => new CartItemForOrder
            {
                ProductId = c.ProductId,
                Quantity = c.Quantity
            });

            var (success, error, orderId) = await _orderServices.CreateOrderFromCartAsync(
                userId,
                cartItemsForOrder,
                shippingName: model.FullName,
                shippingAddress: model.Address,
                shippingCity: model.City);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, error ?? "Order creation failed.");
                return View(model);
            }

            // Clear the session cart after successful order
            _cartService.ClearCart();

            return RedirectToAction("Confirmation", new { orderId });
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(int orderId)
        {
            var userId = _userManager.GetUserId(User);
            var order = await _orderServices.GetByIdAsync(orderId);

            // Ownership check — user can only see their own confirmation
            if (order == null || order.UserId != userId)
                return NotFound();

            return View(order);
        }
    }
}
