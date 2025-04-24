using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class StaticPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
