using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class CommodityController : ControllerBase
    {
        private readonly ICommodityManager _commodityManager;
        public readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;
        public readonly ILogger<CommodityController> _logger;
     
        public CommodityController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<CommodityController> logger)
        {
            _logger = logger;    
            _configuration = configuration;
            _context = context;
            _commodityManager = new CommodityManager(_context, _configuration);
        }
    }
}