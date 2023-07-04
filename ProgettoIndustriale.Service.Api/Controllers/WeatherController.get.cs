using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Business;


namespace ProgettoIndustriale.Service.Api.Controllers;


public partial class WeatherController
{

    [HttpGet("getAllWeathers")]

    public List<Dto.Weather>GetAllWeathers()
    {
        return _weatherManager.GetAllWeathers();
    }


}

