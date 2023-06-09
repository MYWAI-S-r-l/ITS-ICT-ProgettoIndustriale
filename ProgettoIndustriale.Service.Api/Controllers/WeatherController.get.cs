﻿using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Business;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class WeatherController
{

    [HttpGet("getAllWeathers")]

    public List<Dto.Weather>GetAllWeathers()
    {
        return _weatherManager.GetAllWeathers();
    }

    [HttpGet("getWeathersbyDates")]

    public object GetWeathersbyDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
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
}

