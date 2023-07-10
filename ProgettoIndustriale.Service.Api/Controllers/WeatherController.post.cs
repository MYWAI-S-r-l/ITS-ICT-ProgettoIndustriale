using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;
public partial class WeatherController
{
    [HttpPost("getWeathersbyProvince")]

    public List<Dto.Weather> GetWeathersbyProvinces(List<string> province)
    {
        return _weatherManager.GetWeathersbyProvinces(province);
    }
    [HttpPost("getWeathersbyDates")]

    public object GetWeathersbyDates(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            return BadRequest("La data di inizio non può essere successiva alla data di fine");
        }

        if (startDate > DateTime.Now)
        {
            return BadRequest("La data di inizio non può essere futura.");
        }
        return _weatherManager.GetWeathersbyDates(startDate, endDate);
    }

    [HttpPost("getWeathersbyProvincesDates")]

    public object GetWeathersbyProvincesDates(List<string> province, DateTime startDate, DateTime endDate)
    {
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
