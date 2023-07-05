using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class UtilsController : ControllerBase
{
    
    private readonly IUtilsManager _utilsManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
   
    public UtilsController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _utilsManager = new UtilsManager(_context);
    }
}