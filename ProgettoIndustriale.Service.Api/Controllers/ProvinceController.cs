using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Type;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class ProvinceController : ControllerBase
{
    private readonly IProvinceManager _provinceManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;

    public ProvinceController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _provinceManager = new ProvinceManager(_context);
    }
}