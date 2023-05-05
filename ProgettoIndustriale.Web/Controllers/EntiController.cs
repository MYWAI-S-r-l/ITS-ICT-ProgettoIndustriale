using Microsoft.AspNetCore.Mvc;

namespace Ansaldo.Protocollo.Web.Controllers;

public class EntiController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Insert()
    {
        return View();
    }
}