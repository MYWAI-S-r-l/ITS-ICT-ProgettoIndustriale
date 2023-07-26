using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    public partial class LoadController
    {
        [HttpGet("getLoadAll")]
        public IEnumerable<Dto.Load> getAllLoad()
        {
           return _loadManager.getAllLoads();
        }

        [HttpGet("getLoadByFilter")]
        public object getLoadByFilter([BindRequired] string macrozone, [BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
        {
            if (macrozone=="")
            {
                _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getLoadByFilter() inserire una macrozone");

                return BadRequest("Inserire una macrozone");
            }
            if (CheckDate.TryDateCheck(startDate, endDate))
            {
                return _loadManager.getLoadsbyFilter(macrozone, startDate, endDate);
            }
            else
            {
                _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getLoadByFilter() " + CheckDate.errorMessage);

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
            else
            {
                _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getLoadbyDates() " + CheckDate.errorMessage);

                return new BadRequestObjectResult(CheckDate.errorMessage);
            }
        }
    }
}