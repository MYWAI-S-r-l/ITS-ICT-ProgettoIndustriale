using Ansaldo.Protocollo.Business.Imp;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    [ApiController]
    public partial class CommodityController:ControllerBase
    {
        private readonly ICommodityManager _commodityManager;
        private readonly IConfiguration _configuration;
        private readonly ProgettoIndustrialeContext _context;

        public CommodityController(IConfiguration configuration, ProgettoIndustrialeContext context)
        {
            _configuration = configuration;
            _context = context;
            _commodityManager = new CommodityManager(_context);
        }

        public IConfiguration Configuration => _configuration;
    }
}
