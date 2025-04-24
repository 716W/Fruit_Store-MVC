using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // 

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
<<<<<<< HEAD
=======

        return View();
    }
>>>>>>> ae01f4f5f8a211262142acbfaa6c20a295b42b3a

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
