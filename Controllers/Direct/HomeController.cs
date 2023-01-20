using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBaseDemo.Models;

namespace RoleBaseDemo.Controllers.Direct;
[Route("Direct/Home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Hello world");
        return View("Direct/Index");
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize(Policy = "UserPolicy")]
    public IActionResult UserPolicy()
    {
        return View();
    }

    [Authorize(Roles = "User")]
    public ActionResult UserRole()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public ActionResult AdminRole()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
