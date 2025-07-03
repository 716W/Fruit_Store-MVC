using Fruit_Store.Core.Interfaces.Services;
using Fruit_Store_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly ICouponServices _couponServices;

        public CartController(IOrderServices orderServices, ICouponServices couponServices)
        {
            _orderServices = orderServices;
            _couponServices = couponServices;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var viewModel = new CartViewModel
            {
                orders =  await _orderServices.GetAllAsync(),
                coupons = await _couponServices.GetAllAsync()
            };

            return View(viewModel);
        }
    }
}
