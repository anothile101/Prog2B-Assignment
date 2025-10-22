using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using prog_practice.Models;

namespace prog_practice.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [HttpPost]
    public IActionResult Login(string username, string password, string role)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Error = "Please enter both a username and password.";
            return View();
        }

        if (role == "Coordinator")
            return RedirectToAction("Dashboard", "Coordinator");
        else if (role == "Manager")
            return RedirectToAction("Dashboard", "Manager");
        else
            return RedirectToAction("Dashboard", "Lecturer");
    }
}

//    private readonly ILogger<HomeController> _logger;

//    public HomeController(ILogger<HomeController> logger)
//    {
//        _logger = logger;
//    }

//    public IActionResult Index()
//    {
//        return View();
//    }

//    public IActionResult Privacy()
//    {
//        return View();
//    }

//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}
