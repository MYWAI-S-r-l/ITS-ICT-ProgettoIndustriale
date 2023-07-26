using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class WeatherController
{
    [HttpGet("getAllWeathers")]
    public List<Dto.Weather> GetAllWeathers()
    {
        return _weatherManager.GetAllWeathers();     
    }

    [HttpGet("getWeathersbyDates")]
    public object GetWeathersbyDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {
        if (CheckDate.TryDateCheck(startDate, endDate))
        {
            return _weatherManager.GetWeathersbyDates(startDate, endDate);
        }
        else
        {
            _genericLogger.logMessageTemplate(path: this.ToString()!, logType: "error", message: "getWeathersbyDates() " + CheckDate.errorMessage);

            return new BadRequestObjectResult(CheckDate.errorMessage);
        }
    }
}