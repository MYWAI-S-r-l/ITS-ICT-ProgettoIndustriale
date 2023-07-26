
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using Ansaldo.Protocollo.Business.Imp;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class LoadController : ControllerBase
    {
        private readonly ILoadManager _loadManager;
        public readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;
        public readonly ClassLog _genericLogger = new ClassLog();
        public readonly ILogger<LoadController> _detailedLogger;
        public LoadController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<LoadController> logger)
        {
            _configuration = configuration;
            _context = context;
            _detailedLogger = logger;
            _detailedLogger.LogInformation(UtilsFunctions.SubstringController(this));
            _loadManager = new LoadManager(_context, _genericLogger);
        }
    }
}