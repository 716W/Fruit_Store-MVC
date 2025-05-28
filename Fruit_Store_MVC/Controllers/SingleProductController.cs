using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class SingleProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
