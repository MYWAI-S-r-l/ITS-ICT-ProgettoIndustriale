using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Dto = ProgettoIndustriale.Type.Dto;

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
        if ( CheckDate.TryDateCheck(DateTime startDate, endDate))
        {
            return _priceManager.GetPricesbyDates(startDate, endDate);
        }

        
        return BadRequest(CheckDate.errorMessage)
    }
}