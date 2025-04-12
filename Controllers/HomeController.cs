using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Fruit_Store_MVC.Models;

namespace Fruit_Store_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index_2()
    {
        return View();
    }

    public IActionResult Page404()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult CheckOut()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult News()
    {
        return View();
    }

    public IActionResult Shop()
    {
        return View();
    }

    public IActionResult SingleNews()
    {
        return View();
    }

    public IActionResult SingleProduct()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
