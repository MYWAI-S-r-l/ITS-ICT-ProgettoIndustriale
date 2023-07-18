using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    public partial class CommodityController : ControllerBase
    {
        private readonly ICommodityManager _commodityManager;
        public readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;
        public readonly Serilog.ILogger _logger;
        public CommodityController(IConfiguration configuration, ProgettoIndustrialeContext context, Serilog.ILogger logger)
        {

            _configuration = configuration;
            _context = context;
            _commodityManager = new CommodityManager(_context);
            _logger = logger;
            
        }
    }
}