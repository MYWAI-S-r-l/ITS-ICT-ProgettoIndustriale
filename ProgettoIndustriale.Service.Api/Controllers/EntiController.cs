using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Type;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class EntiController : ControllerBase
{
    private readonly IEntiManager _entiManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;

    public EntiController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _entiManager = new EntiManager(_context);
    }
}