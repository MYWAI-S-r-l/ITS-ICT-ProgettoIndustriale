using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class WeatherController : ControllerBase
{
    private readonly IWeatherManager _weatherManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;

    public WeatherController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _weatherManager = new WeatherManager(_context);
    }
}