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
    public readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
    public readonly ILogger<WeatherController> _detailedLogger;
    public readonly ClassLog _genericLogger = new ClassLog();
    public WeatherController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<WeatherController> logger)
    {
        _configuration = configuration;
        _context = context;
        _detailedLogger= logger;
        _detailedLogger.LogInformation(UtilsFunctions.SubstringController(this));
        _weatherManager = new WeatherManager(_context, _genericLogger);
 		
    }
}