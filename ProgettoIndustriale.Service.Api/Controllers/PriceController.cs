using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class PriceController : ControllerBase
{
    private readonly IPriceManager _priceManager;
    public readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
    public readonly ILogger<PriceController> _logger;

    public PriceController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<PriceController> logger)
    {
        _configuration = configuration;
        _context = context;
        _logger = logger;
        _priceManager = new PriceManager(_context, configuration);
    }

    
}