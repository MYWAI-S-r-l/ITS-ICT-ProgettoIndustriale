using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class WeatherController
{
    [HttpPost("getWeathersbyProvince")]
    public Object GetWeathersbyProvinces([BindRequired] List<string> province)
    {
        if (province[0] == "string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        return _weatherManager.GetWeathersbyProvinces(province);
    }

    [HttpPost("getWeathersbyProvincesDates")]
    public object GetWeathersbyProvincesDates([BindRequired] List<string> province, [BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {
        if (province[0] == "string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        if (CheckDate.TryDateCheck(startDate, endDate))
        {
            return _weatherManager.GetWeathersbyProvincesDates(province, startDate, endDate);
        }
        return BadRequest(CheckDate.errorMessage);
    }
}