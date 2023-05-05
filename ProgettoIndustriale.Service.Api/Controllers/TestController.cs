using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("Exc")]
        public IActionResult Exc()
        {
            throw new Exception("Eccezione di TEST per ELMAH su API");
        }
    }
}
