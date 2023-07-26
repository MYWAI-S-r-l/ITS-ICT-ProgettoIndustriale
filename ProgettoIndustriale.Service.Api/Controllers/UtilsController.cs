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
    public readonly ClassLog _genericLogger = new ClassLog();
    public readonly ILogger<UtilsController> _detailedLogger;

    public UtilsController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<UtilsController> logger)
    {
        
        _configuration = configuration;
        _context = context;
        _detailedLogger = logger;
        _detailedLogger.LogInformation(UtilsFunctions.SubstringController(this));
        _utilsManager = new UtilsManager(_context, _genericLogger);
    }


}