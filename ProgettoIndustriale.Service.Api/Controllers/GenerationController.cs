using Ansaldo.Protocollo.Business.Imp;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class GenerationController : ControllerBase
{
    private readonly IGenerationManager _generationManager;
    public readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
    public readonly ClassLog _genericLogger = new ClassLog();
    public readonly ILogger<GenerationController> _detailedLogger;

    public GenerationController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<GenerationController> logger)
    {
        _configuration = configuration;
        _context = context;
        _detailedLogger = logger;
        _detailedLogger.LogInformation(UtilsFunctions.SubstringController(this));
        _generationManager = new GenerationManager(_context, _genericLogger);
    }
}