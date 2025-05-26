using Fruit_Store_MVC.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Fruit_Store_MVC.Controllers
{
    public class StaticPageController : Controller
    {

        //private readonly IHomeService _homeService;

        //public StaticPageController(IHomeService homeService)
        //{
        //    _homeService = homeService;
        //}

        //public async Task<IActionResult> staticPage()
        //{
        //    var ViewModel = await _homeService.GetHomePageData();
        //    return View(ViewModel);
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
