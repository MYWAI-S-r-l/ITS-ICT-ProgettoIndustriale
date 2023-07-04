using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Globalization;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class PriceController
{
    [HttpPost("getGetPricesbyMacrozones")]
    public List<Dto.Price> GetPricesbyMacrozones(List<string> macrozone)
    {
        return _priceManager.GetPricesbyMacrozones(macrozone);
    }

    [HttpPost("getGetPricesbyMacrozonesDates")]
    public List<Dto.Price> GetPricesbyMacrozonesDates(List<string> macrozone, DateTime startDate, DateTime endDate)
    {
        return _priceManager.GetPricesbyMacrozonesDates(macrozone, startDate, endDate);
    }
}


