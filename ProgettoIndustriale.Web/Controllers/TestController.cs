using Microsoft.AspNetCore.Mvc;

namespace Ansaldo.Protocollo.Web.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}