using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class PriceController
{
    [HttpGet("get/{codice}")]
    public Dto.Price? GetPrice(string codice)
    {
        return _priceManager.GetPrice(codice);
    }

    [HttpGet("getAll")]
    public List<Dto.Price> GetPrice()
    {
        return _priceManager.GetAllPrice();
    }

}

