using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public object getLoadByFilter([BindRequired] string macrozone, [BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
        {
          
            if (CheckDate.TryDateCheck(startDate, endDate))
            {

                return _loadManager.getLoadsbyFilter(macrozone, startDate, endDate);
            }
            else
            {
               
                _logger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getLoadByFilter() " + CheckDate.errorMessage);

                return new BadRequestObjectResult(CheckDate.errorMessage);
            }



        }

        [HttpGet("getLoadbyDates")]
        public object getLoadByDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
        {
            if (CheckDate.TryDateCheck(startDate, endDate))
            {
                return _loadManager.getloadbyDates(startDate, endDate); 
            }

            return BadRequest(CheckDate.errorMessage);
        }
    }
}