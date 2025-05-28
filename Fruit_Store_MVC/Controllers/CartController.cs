using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
