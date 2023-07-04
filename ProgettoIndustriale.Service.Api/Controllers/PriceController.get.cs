using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class PriceController
{

    [HttpGet("getAllPrices")]
    public List<Dto.Price> GetAllPrices()
    {
        return _priceManager.GetAllPrices();
    }

    [HttpGet("getPricesbyDates")]
    public object GetPricesbyDates([BindRequired] DateTime startDate, [BindRequired] DateTime endDate)
    {
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

