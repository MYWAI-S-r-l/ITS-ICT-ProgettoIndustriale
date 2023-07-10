using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class PriceController
{
    [HttpPost("getGetPricesbyMacrozones")]
    public object GetPricesbyMacrozones(List<string> macrozone)
    {
        if (macrozone.First() == "string" || macrozone.First().IsNullOrEmpty())
        {
            return BadRequest("Inserire almeno una macrozone");
        }
        return _priceManager.GetPricesbyMacrozones(macrozone);
    }

    [HttpPost("getGetPricesbyMacrozonesDates")]
    public object GetPricesbyMacrozonesDates(List<string> macrozone, DateTime startDate = default, DateTime endDate = default)
    {
        if (macrozone.First() == "string" || macrozone.First().IsNullOrEmpty())
        {
            return BadRequest("Inserire almeno una macrozone");
        }
        if (startDate > endDate)
        {
            return BadRequest("La data di inizio non può essere successiva alla data di fine");
        }

        if (startDate > DateTime.Now)
        {
            return BadRequest("La data di inizio non può essere futura.");

        }
        if (startDate == default || endDate == default)
        {
            return BadRequest("Inserire data");
        }

        return _priceManager.GetPricesbyMacrozonesDates(macrozone, startDate, endDate);
    }
}


