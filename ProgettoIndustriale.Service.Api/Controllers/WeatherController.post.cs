using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;
public partial class WeatherController
{
    [HttpPost("getWeathersbyProvince")]

    public Object GetWeathersbyProvinces([BindRequired] List<string> province)
    {
        if(province.First() =="string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        return _weatherManager.GetWeathersbyProvinces(province);
    }
    

    [HttpPost("getWeathersbyProvincesDates")]

    public object GetWeathersbyProvincesDates([BindRequired] List<string> province, [BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {
        if (province.First() == "string")
        {
            return BadRequest("inserire almeno una provincia");
        }
        if (startDate > endDate)
        {
            return BadRequest("La data di inizio non può essere successiva alla data di fine");
        }

        if (startDate > DateTime.Now)
        {
            return BadRequest("La data di inizio non può essere futura.");
        }
        return _weatherManager.GetWeathersbyProvincesDates(province, startDate, endDate);
    }
}
