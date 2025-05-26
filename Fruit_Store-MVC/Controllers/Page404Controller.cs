using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class Page404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
