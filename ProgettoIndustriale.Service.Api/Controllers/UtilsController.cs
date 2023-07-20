using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class UtilsController : ControllerBase
{
    private readonly IUtilsManager _utilsManager;
    public readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
    public readonly ILogger<UtilsController> _logger;

    public UtilsController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<UtilsController> logger)
    {
        
        _configuration = configuration;
        _context = context;
        _utilsManager = new UtilsManager(_context, configuration);
        _logger = logger;
    }


}