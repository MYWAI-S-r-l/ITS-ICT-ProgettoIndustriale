using Microsoft.AspNetCore.Mvc;
using dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    public partial class LoadController 
    {
        [HttpPost("getLoadbyDates")]
        public IEnumerable<dto.Load> getByMacrozone(List<string> macrozones)
        {
            return _loadManager.getLoadbyMacrozone(macrozones);

        }
    }
}
