using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
