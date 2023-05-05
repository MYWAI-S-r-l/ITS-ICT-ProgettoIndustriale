using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ansaldo.Protocollo.Web.Models;

namespace ProgettoIndustriale.Web.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ClaimsWeb()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }
    
    public IActionResult Exc()
    {
        throw new Exception("Eccezione di TEST per ELMAH");
    }
}
