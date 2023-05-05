using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}
