using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class PriceController
{

    [HttpGet("getAllPrices")]
    public List<Dto.Price> GetAllPrices()
    {
        return _priceManager.GetAllPrices();
    }

    [HttpGet("getPricesbyDates")]
    public List<Dto.Price> GetPricesbyDates(DateTime startDate, DateTime endDate)
    {
        return _priceManager.GetPricesbyDates(startDate, endDate);
    }

    [HttpGet("getGetPricesbyMacrozones")]
    public List<Dto.Price> GetPricesbyMacrozones(List<string> macrozone)
    {
        return _priceManager.GetPricesbyMacrozones(macrozone);
    }

    [HttpGet("getGetPricesbyMacrozonesDates")]
    public List<Dto.Price> GetPricesbyMacrozonesDates(List<string> macrozone, DateTime startDate, DateTime endDate)
    {
        return _priceManager.GetPricesbyMacrozonesDates(macrozone, startDate, endDate);
    }


}

