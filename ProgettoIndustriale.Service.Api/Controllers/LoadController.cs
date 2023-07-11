using Ansaldo.Protocollo.Business.Imp;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    public partial class LoadController:ControllerBase
    {
        private readonly ILoadManager _loadManager;
        private readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;

        public LoadController(IConfiguration configuration, ProgettoIndustrialeContext context)
        {
            _configuration = configuration;
            _context = context;
            _loadManager = new LoadManager(_context);
        }

    }
}
