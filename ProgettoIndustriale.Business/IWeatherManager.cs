using System.Collections.Generic;
using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *              Weather
 * ************************************/


public interface IWeatherManager
{
    public List<Dto.Weather> GetAllWeather();
    public List<Dto.Weather> GetWeatherbyProvince(List<string> province);
    public List<Dto.Weather> GetWeatherbyDate(DateTime startDate, DateTime endDate);
    public List<Dto.Weather> GetWeatherbyProvinceDate(List<string> province, DateTime startDate, DateTime endDate);

}