using Microsoft.AspNetCore.Mvc;
using dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    public partial class LoadController 
    {
        [HttpGet("getLoadAll")]
        public IEnumerable<dto.Load> getAllLoad()
        {
            return _loadManager.getAllLoads();
        }


        [HttpGet("getLoadByFilter")]

        public IEnumerable<dto.Load> getLoadByFilter(string macrozone, DateTime startDate, DateTime endTime)
        {
            return _loadManager.getLoadsbyFilter(macrozone, startDate, endTime);

        }

        [HttpGet("getLoadbyDates")]
        public IEnumerable<dto.Load> getLoadByDates(DateTime startDate, DateTime endDate)
        {
            return _loadManager.getloadbyDates(startDate, endDate);
        }
        

    }
}
