using System.Collections.Generic;
using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;
/***************************************
 *              Weather
 * ************************************/


public interface IWeatherManager

{
    public List<Dto.Weather> GetAllWeathers();
    public List<Dto.Weather> GetWeathersbyProvinces(List<string> province);
    public List<Dto.Weather> GetWeathersbyDates(DateTime startDate, DateTime endDate);
    public List<Dto.Weather> GetWeathersbyProvincesDates(List<string> province, DateTime startDate, DateTime endDate);

}