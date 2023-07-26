using Ansaldo.Protocollo.Business.Imp;
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
        public readonly ClassLog _genericLogger = new ClassLog();
        public readonly ILogger<CommodityController> _detailedLogger;

        public CommodityController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<CommodityController> logger)
        {
            _configuration = configuration;
            _context = context;
            _detailedLogger= logger;    
            _detailedLogger.LogInformation(UtilsFunctions.SubstringController(this));
            _commodityManager = new CommodityManager(_context, _genericLogger);
        }
    }
}