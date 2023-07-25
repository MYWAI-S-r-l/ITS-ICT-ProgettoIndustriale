using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class WeatherController
{
    [HttpGet("getAllWeathers")]
    public List<Dto.Weather> GetAllWeathers()
    {
        try
        {
            return _weatherManager.GetAllWeathers();
        }
        catch (Exception)
        { 
            
            return new List<Dto.Weather>();

        }
        
    }

    [HttpGet("getWeathersbyDates")]
    public object GetWeathersbyDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {
        if (CheckDate.TryDateCheck(startDate, endDate))
        {
            return _weatherManager.GetWeathersbyDates(startDate, endDate);

        }
        return BadRequest(CheckDate.errorMessage);
    }
}