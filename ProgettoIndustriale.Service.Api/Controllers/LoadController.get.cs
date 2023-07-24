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
                return new BadRequestObjectResult(CheckDate.errorMessage);
            }



        }

        [HttpGet("getLoadbyDates")]
        public object getLoadByDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("La data di inizio non può essere successiva alla data di fine");
            }

            if (startDate > DateTime.Now)
            {
                return BadRequest("La data di inizio non può essere futura");
            }
            if (startDate == default || endDate == default)
            {
                return BadRequest("Inserire data");
            }
            return _loadManager.getloadbyDates(startDate, endDate);
        }
    }
}