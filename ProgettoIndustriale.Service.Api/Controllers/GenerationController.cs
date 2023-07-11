using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Business;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class GenerationController : ControllerBase
{
    
    private readonly IGenerationManager _generationManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
   
    public GenerationController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _generationManager =new GenerationManager(_context);
    }
}