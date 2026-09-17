using Fruit_Store.Core.Interfaces.Services;
using Fruit_Store_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly IProductServices _productServices;

        public CartController(CartService cartService, IProductServices productServices)
        {
            _cartService = cartService;
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (productId <= 0 || quantity <= 0)
            {
                TempData["CartError"] = "Invalid product or quantity.";
                return RedirectToAction("Index", "Shop");
            }

            // Fetch real product data from DB — never trust user-submitted prices
            var product = await _productServices.GetByIdAsync(productId);
            if (product == null)
            {
                TempData["CartError"] = "Product not found.";
                return RedirectToAction("Index", "Shop");
            }

            var referer = Request.Headers["Referer"].ToString();

            if (product.Quantity <= 0)
            {
                TempData["CartError"] = $"{product.Name} is out of stock.";
                if (!string.IsNullOrEmpty(referer) && Url.IsLocalUrl(referer))
                    return Redirect(referer);
                return RedirectToAction("Index", "Shop");
            }

            if (quantity > product.Quantity)
            {
                TempData["CartError"] = $"Only {product.Quantity} units of {product.Name} are available.";
                quantity = product.Quantity;
            }

            _cartService.AddToCart(productId, product.Name ?? "Product", product.Price, quantity, product.ImageUrl);
            TempData["CartSuccess"] = $"{product.Name} added to cart!";

            if (!string.IsNullOrEmpty(referer) && Url.IsLocalUrl(referer))
                return Redirect(referer);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            if (quantity < 0)
            {
                TempData["CartError"] = "Invalid quantity.";
                return RedirectToAction("Index");
            }

            _cartService.UpdateQuantity(productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveItem(int productId)
        {
            _cartService.RemoveItem(productId);
            TempData["CartSuccess"] = "Item removed from cart.";
            return RedirectToAction("Index");
        }
    }
}
