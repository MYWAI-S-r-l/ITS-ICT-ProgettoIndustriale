using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class PriceController
{
    [HttpPost("getPricesbyMacrozones")]
    public object GetPricesbyMacrozones( [BindRequired] List<string> macrozone)
    {
        if (macrozone.First() == "string")
        {
            return BadRequest("Inserire almeno una macrozone");
        }
        return _priceManager.GetPricesbyMacrozones(macrozone);
    }

    [HttpPost("getPricesbyMacrozonesDates")]
    public object GetPricesbyMacrozonesDates([BindRequired] List<string> macrozone, [BindRequired] DateTime startDate = default, [BindRequired] DateTime endDate = default)
    {
        if (macrozone.First() == "string")
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
        

        return _priceManager.GetPricesbyMacrozonesDates(macrozone, startDate, endDate);
    }
}


