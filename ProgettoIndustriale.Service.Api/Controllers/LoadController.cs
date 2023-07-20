using Ansaldo.Protocollo.Business.Imp;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class LoadController : ControllerBase
    {
        private readonly ILoadManager _loadManager;
        public readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;
        public readonly ILogger<LoadController> _logger;

        public LoadController(IConfiguration configuration, ProgettoIndustrialeContext context, ILogger<LoadController> logger)
        {
            _configuration = configuration;
            _context = context;
            _loadManager = new LoadManager(_context, configuration);
            _logger = logger;        }
    }
}