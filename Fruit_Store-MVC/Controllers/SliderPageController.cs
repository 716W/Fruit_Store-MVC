using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class SliderPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
