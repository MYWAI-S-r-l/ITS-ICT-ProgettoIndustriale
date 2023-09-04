using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Web.Controllers
{
    public class ProgettoWebController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
