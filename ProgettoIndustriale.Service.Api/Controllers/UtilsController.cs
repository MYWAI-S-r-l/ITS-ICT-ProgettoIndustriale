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

    public UtilsController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _utilsManager = new UtilsManager(_context, configuration);
    }


}