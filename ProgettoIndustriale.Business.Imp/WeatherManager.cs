using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using Dom = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Serilog;
namespace ProgettoIndustriale.Business.Imp;

public class WeatherManager : IWeatherManager

{
    private readonly ProgettoIndustrialeContext _context;
    public ClassLog _logger { get; set; }
    public WeatherManager(ProgettoIndustrialeContext context, IConfiguration config)
    {
        _context = context;
        _logger = new ClassLog(config);
    }

    public List<Dto.Weather> GetAllWeathers()
    {
        try
        {
            var allWeathers = _context.Weather
                .Include(x => x.Province)
                .Include(x => x.Date).ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetAllWeathers() ritorna " + allWeathers.Count.ToString() + " elementi");

            return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Weather>();
        }
    }

    public List<Dto.Weather> GetWeathersbyProvinces(List<string> province)
    {
        try
        {
            var allWeathers = _context.Weather

                .Include(x => x.Date!)
                .Include(x => x.Province!)
                .ThenInclude(x => x.Region!)
                .ThenInclude(x => x.MacroZone!)
                .Where(x => x.Province != null && x.Date != null && x.Province.Name != null && province.Contains(x.Province.Name))
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetWeathersbyProvinces() ritorna " + allWeathers.Count.ToString() + " elementi");


            return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Weather>();
        }
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
        try
        {
            var allWeathers = _context.Weather
                .Include(x => x.Province!)
                .ThenInclude(x => x.Region!)
                .ThenInclude(x => x.MacroZone)
                .Include(x => x.Date!)
                .Where(x => x.Date != null && x.Date.DateTime > startDate && x.Date.DateTime < endDate)
                .ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetWeathersbyDates() ritorna " + allWeathers.Count.ToString() + " elementi");


            return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Weather>();
        }
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
        try
        {
            var allWeathers = _context.Weather
                .Include(x => x.Province!)
                .ThenInclude(x => x.Region!)
                .ThenInclude(x => x.MacroZone!)
                .Include(x => x.Date!)
                .Where(x => x.Province != null && x.Date != null && x.Province.Name != null &&
                x.Date.DateTime > startDate && x.Date.DateTime < endDate && province
                .Contains(x.Province.Name)).ToList();

            _logger.logMessageTemplate(path: this.ToString()!, logType: "debug", message: "GetWeathersbyProvincesDates() ritorna " + allWeathers.Count.ToString() + " elementi");


            return MyMapper<Dom.Weather, Dto.Weather>.MapList(allWeathers);
        }
        catch(Exception ex)
        {
            _logger.logMessageTemplate(path: this.ToString()!, e: ex);

            return new List<Dto.Weather>();
        }
    }
}