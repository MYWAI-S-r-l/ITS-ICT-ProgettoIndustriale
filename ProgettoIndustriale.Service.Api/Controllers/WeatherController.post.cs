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

    public List<Dto.Weather> GetWeathersbyDates(DateTime startDate, DateTime endDate)
    {
        return _weatherManager.GetWeathersbyDates(startDate, endDate);
    }

    [HttpPost("getWeathersbyProvincesDates")]

    public List<Dto.Weather> GetWeathersbyProvincesDates(List<string> province, DateTime startDate, DateTime endDate)
    {
        return _weatherManager.GetWeathersbyProvincesDates(province, startDate, endDate);
    }
}
