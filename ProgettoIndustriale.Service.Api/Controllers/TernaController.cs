using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Type;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class TernaController : ControllerBase
{
    private readonly ITernaManager _ternaManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;

    public TernaController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _ternaManager = new TernaManager(_context);
    }
}