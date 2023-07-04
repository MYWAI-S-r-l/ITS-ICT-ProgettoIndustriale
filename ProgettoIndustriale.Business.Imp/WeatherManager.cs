using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Dom = ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Data;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business.Imp;
public class WeatherManager : IWeatherManager

{
    private readonly ProgettoIndustrialeContext _context;
    public WeatherManager(ProgettoIndustrialeContext context)
    { 
        _context= context;
    }
    public List<Dto.Weather> GetAllWeathers()
    {

        var allWeathers = _context.Weather.ToList();
        return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);

    }

    public List<Dto.Weather> GetWeathersbyProvinces(List<string> province)
    {
        var allWeathers = _context.Weather.Include(x => x.Province)
            .Where(x => province.Contains(x.Province.Name)).ToList();
        return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        
    }


    public List<Dto.Weather> GetWeathersbyDates(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("La data di inizio non può essere successiva alla data di fine.");
        }

        if (startDate > DateTime.Today)
        {
            throw new ArgumentException("La data di inizio non può essere futura.");
        }

        var allWeathers = _context.Weather
            .Where(x => x.Date.DateTime > startDate && x.Date.DateTime < endDate).ToList();
        return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);

    }

    public List<Dto.Weather> GetWeathersbyProvincesDates(List<string> province, DateTime startDate, DateTime endDate)
    {

        if (startDate > endDate)
        {
            throw new ArgumentException("La data di inizio non può essere successiva alla data di fine.");
        }

        if (startDate > DateTime.Today)
        {
            throw new ArgumentException("La data di inizio non può essere futura.");
        }


        var allWeathers = _context.Weather.Include(x => x.Province)
        .Include(x => x.Date)
            .Where(x => x.Date.DateTime > startDate && x.Date.DateTime < endDate && province
            .Contains(x.Province.Name)).ToList();
        return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        

    }

}
