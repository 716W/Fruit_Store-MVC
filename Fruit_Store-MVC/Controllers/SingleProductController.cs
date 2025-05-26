using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class SingleProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
