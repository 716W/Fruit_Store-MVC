using Microsoft.AspNetCore.Mvc;

namespace FruitStore.MVC.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
