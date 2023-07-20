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
    public readonly ILogger<GenerationController> _logger;

    public GenerationController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<GenerationController> logger)
    {
        _configuration = configuration;
        _context = context;
        _logger = logger;
        _generationManager = new GenerationManager(_context, configuration);
    }
}