using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IWeatherManager
{
    Dto.Weather? GetWeather(int id);

    List<Dto.Weather> GetAllWeathers();
}

