using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class SingleNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
